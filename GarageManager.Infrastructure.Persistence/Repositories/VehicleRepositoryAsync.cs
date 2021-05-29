using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Domain.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GarageManager.Infrastructure.Persistence.Repositories
{
    public class VehicleRepositoryAsync : GenericRepositoryAsync<Vehicle>, IVehicleRepositoryAsync
    {
        private readonly DbSet<Vehicle> _vehicles;

        public VehicleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _vehicles = dbContext.Set<Vehicle>();
        }

        public async Task<bool> IsUniqueRegistrationNumberAsync(string regNumber)
        {
            return await _vehicles
                .AllAsync(p => p.RegistrationNumber != regNumber);
        }
    }
}
