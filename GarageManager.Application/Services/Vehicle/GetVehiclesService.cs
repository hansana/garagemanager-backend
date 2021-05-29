using AutoMapper;
using GarageManager.Application.Interfaces.Repositories;
using GarageManager.Application.Parameters;
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
    public class GetVehiclesService : IRequest<PagedResponse<IEnumerable<VehicleModel>>>
    {
        public GetVehicleParameter VehicleParameter { get; set; }
    }

    public class GetVehicleServiceHandler : IRequestHandler<GetVehiclesService, PagedResponse<IEnumerable<VehicleModel>>>
    {
        private readonly IVehicleRepositoryAsync _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleServiceHandler(IVehicleRepositoryAsync vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<VehicleModel>>> Handle(GetVehiclesService request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.GetPagedReponseAsync(request.VehicleParameter.PageNumber, request.VehicleParameter.PageSize);
            var vehicleModels = _mapper.Map<IEnumerable<VehicleModel>>(vehicles);
            return new PagedResponse<IEnumerable<VehicleModel>>(vehicleModels, request.VehicleParameter.PageNumber, request.VehicleParameter.PageSize);
        }
    }
}
