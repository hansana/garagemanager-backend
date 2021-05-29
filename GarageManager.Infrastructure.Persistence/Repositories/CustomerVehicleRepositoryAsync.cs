using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Infrastructure.Persistence.Repositories
{
    class CustomerVehicleRepositoryAsync : GenericRepositoryAsync<CustomerVehicle>, ICustomerVehicleRepositoryAsync
    {
        private readonly DbSet<CustomerVehicle> _customerVehicles;

        public CustomerVehicleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customerVehicles = dbContext.Set<CustomerVehicle>();
        }
    }
}
