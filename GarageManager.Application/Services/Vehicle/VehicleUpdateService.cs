using AutoMapper;
using GarageManager.Application.Enums;
using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Application.Wrappers;
using GarageManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GarageManager.Application.Services.Vehicle
{
    public class VehicleUpdateService : IRequest<Response<bool>>
    {
        public VehicleModel VehicleModel { get; set; }
    }

    public class VehicleUpdateServiceHandler : IRequestHandler<VehicleUpdateService, Response<bool>>
    {
        private readonly IVehicleRepositoryAsync _vehicleRepositoryAsync;
        private readonly IMapper _mapper;

        public VehicleUpdateServiceHandler(IVehicleRepositoryAsync vehicleRepositoryAsync, IMapper mapper)
        {
            _vehicleRepositoryAsync = vehicleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(VehicleUpdateService request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepositoryAsync.GetByIdAsync(request.VehicleModel.Id);
            if (vehicle == null)
            {
                return new Response<bool>
                {
                    Message = "Vehicle not found",
                    Succeeded = false,
                    Status = ResponseStatus.NotFound
                };
            }

            vehicle.RegistrationNumber = request.VehicleModel.RegistrationNumber;
            vehicle.Brand = request.VehicleModel.Brand;
            vehicle.Model = request.VehicleModel.Model;
            vehicle.ChassisNumber = request.VehicleModel.ChassisNumber;
            vehicle.ManufacturedYear = request.VehicleModel.ManufacturedYear;
            vehicle.VehicleType = request.VehicleModel.VehicleType;
            vehicle.Transmission = request.VehicleModel.Transmission;
            vehicle.LastCheckedIn = request.VehicleModel.LastCheckedIn;

            await _vehicleRepositoryAsync.UpdateAsync(vehicle);

            return new Response<bool>(true);
        }
    }
}
