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
    public class GetVehicleByIdService : IRequest<Response<VehicleModel>>
    {
        public Guid Id { get; set; }
    }

    public class GetVehicleByIdServiceHandler : IRequestHandler<GetVehicleByIdService, Response<VehicleModel>>
    {
        private readonly IVehicleRepositoryAsync _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleByIdServiceHandler(IVehicleRepositoryAsync vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Response<VehicleModel>> Handle(GetVehicleByIdService request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);

            if (vehicle == null)
            {
                return new Response<VehicleModel>
                {
                    Message = "Vehicle not found",
                    Succeeded = false,
                    Status = ResponseStatus.NotFound
                };
            }

            return new Response<VehicleModel>(_mapper.Map<VehicleModel>(vehicle));
        }
    }
}
