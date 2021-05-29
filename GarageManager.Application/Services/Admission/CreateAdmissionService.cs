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

namespace GarageManager.Application.Services.Admission
{
    public class CreateAdmissionService : IRequest<Response<VehicleAdmissionModel>>
    {
        public VehicleAdmissionModel VehicleAdmissionModel { get; set; }
    }

    public class CreateAdmissionServiceHandler : IRequestHandler<CreateAdmissionService, Response<VehicleAdmissionModel>>
    {
        private readonly IVehicleAdmisionRepositoryAsync _vehicleAdmisionRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateAdmissionServiceHandler(IVehicleAdmisionRepositoryAsync vehicleAdmisionRepositoryAsync, IMapper mapper)
        {
            _vehicleAdmisionRepositoryAsync = vehicleAdmisionRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<VehicleAdmissionModel>> Handle(CreateAdmissionService request, CancellationToken cancellationToken)
        {
            var vehicleAdmission = await _vehicleAdmisionRepositoryAsync.AddAsync(_mapper.Map<Domain.DataModels.VehicleAdmission>(request.VehicleAdmissionModel));

            return new Response<VehicleAdmissionModel>(_mapper.Map<VehicleAdmissionModel>(vehicleAdmission));
        }
    }
}
