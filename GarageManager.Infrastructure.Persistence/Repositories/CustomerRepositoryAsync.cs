using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Domain.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Infrastructure.Persistence.Repositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly DbSet<Customer> _customers;

        public CustomerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _customers = dbContext.Set<Customer>();
        }
    }
}
