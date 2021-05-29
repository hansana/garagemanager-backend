using GarageManager.Application.Interfaces;
using GarageManager.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarageManager.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleAdmission> VehicleAdmissions { get; set; }
        public DbSet<VehicleCheckListItem> VehicleCheckLists { get; set; }
        public DbSet<AdmissionCheckListItem> AdmissionCheckLists { get; set; }
        public DbSet<AdmissionRequest> AdmissionRequests { get; set; }
        public DbSet<AdmissionService> AdmissionServices { get; set; }
        public DbSet<CustomerVehicle> CustomerVehicles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseDataModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = _dateTime.NowUtc;
                        entry.Entity.UpdatedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CompoundKeys(modelBuilder);
            Relationships(modelBuilder);
            PerformanceIndexes(modelBuilder);
            DecimalFormatting(modelBuilder);
        }

        private static void CompoundKeys(ModelBuilder modelBuilder)
        {
        }

        private static void Relationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerVehicle>().HasOne(cv => cv.Customer).WithMany(c => c.CustomerVehicles).HasForeignKey(cv => cv.CustomerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CustomerVehicle>().HasOne(cv => cv.Vehicle).WithMany(v => v.CustomerVehicles).HasForeignKey(cv => cv.VehicleId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VehicleAdmission>().HasOne(va => va.Vehicle).WithMany(v => v.VehicleAdmissions).HasForeignKey(va => va.VehicleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<VehicleAdmission>().HasOne(va => va.Customer).WithMany(c => c.VehicleAdmissions).HasForeignKey(va => va.CustomerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<VehicleAdmission>().HasOne(va => va.User).WithMany(u => u.VehicleAdmissions).HasForeignKey(va => va.HandledBy).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AdmissionCheckListItem>().HasOne(acli => acli.VehicleAdmission).WithMany(va => va.CheckListItems).HasForeignKey(acli => acli.AdmissionId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AdmissionCheckListItem>().HasOne(acli => acli.CheckListItem).WithMany(cli => cli.AdmissionCheckListItems).HasForeignKey(acli => acli.CheckListId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AdmissionService>().HasOne(ads => ads.VehicleAdmission).WithMany(va => va.AdmissionServices).HasForeignKey(ads => ads.AdmissionId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AdmissionService>().HasOne(ads => ads.User).WithMany(u => u.AdmissionServices).HasForeignKey(ads => ads.HandledBy).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AdmissionService>().HasOne(ads => ads.AdmissionRequest).WithOne(ar => ar.AdmissionService).HasForeignKey<AdmissionService>(ads => ads.AdmissionRequestId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AdmissionRequest>().HasOne(ar => ar.VehicleAdmission).WithMany(va => va.AdmissionRequests).HasForeignKey(ar => ar.AdmissionId).OnDelete(DeleteBehavior.Cascade);
        }

        private static void PerformanceIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerVehicle>().HasIndex(e => new { e.VehicleId, e.CustomerId });
        }

        private static void DecimalFormatting(ModelBuilder modelBuilder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            //base.OnModelCreating(modelBuilder);
        }
    }
}
