using GarageManager.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Application.Interfaces.Repositories
{
    public interface IVehicleRepositoryAsync : IGenericRepositoryAsync<Vehicle>
    {
        Task<bool> IsUniqueRegistrationNumberAsync(string regNumber);
    }
}
