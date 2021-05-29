using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Infrastructure.Persistence.Repositories
{
    public class VehicleAdmisionRepositoryAsync : GenericRepositoryAsync<VehicleAdmission>, IVehicleAdmisionRepositoryAsync
    {
        private readonly DbSet<VehicleAdmission> _vehiclesAdmissions;

        public VehicleAdmisionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _vehiclesAdmissions = dbContext.Set<VehicleAdmission>();
        }
    }
}
