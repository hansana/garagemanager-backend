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

namespace GarageManager.Application.Services.Admission
{
    public class AdmissionByIdService : IRequest<Response<VehicleAdmissionModel>>
    {
        public Guid Id { get; set; }
    }

    public class AdmissionByIdServiceHandler : IRequestHandler<AdmissionByIdService, Response<VehicleAdmissionModel>>
    {
        private readonly IVehicleAdmisionRepositoryAsync _vehicleAdmisionRepositoryAsync;
        private readonly IMapper _mapper;

        public AdmissionByIdServiceHandler(IVehicleAdmisionRepositoryAsync vehicleAdmisionRepositoryAsync, IMapper mapper)
        {
            _vehicleAdmisionRepositoryAsync = vehicleAdmisionRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<VehicleAdmissionModel>> Handle(AdmissionByIdService request, CancellationToken cancellationToken)
        {
            var vehicleAdmission = await _vehicleAdmisionRepositoryAsync.GetByIdAsync(request.Id);

            if (vehicleAdmission == null)
            {
                return new Response<VehicleAdmissionModel>
                {
                    Message = "Customer not found",
                    Succeeded = false,
                    Status = ResponseStatus.NotFound
                };
            }

            return new Response<VehicleAdmissionModel>(_mapper.Map<VehicleAdmissionModel>(vehicleAdmission));
        }
    }
}
