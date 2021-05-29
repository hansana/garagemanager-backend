using AutoMapper;
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
    public class CreateVehicleService : IRequest<Response<VehicleModel>>
    {
        public VehicleModel VehicleModel { get; set; }
    }

    public class CreateVehicleServiceHandler : IRequestHandler<CreateVehicleService, Response<VehicleModel>>
    {
        private readonly IVehicleRepositoryAsync _vehicleRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateVehicleServiceHandler(IVehicleRepositoryAsync vehicleRepositoryAsync, IMapper mapper)
        {
            _vehicleRepositoryAsync = vehicleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<VehicleModel>> Handle(CreateVehicleService request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepositoryAsync.AddAsync(_mapper.Map<Domain.DataModels.Vehicle>(request.VehicleModel));
            return new Response<VehicleModel>(_mapper.Map<VehicleModel>(vehicle));
        }
    }
}
