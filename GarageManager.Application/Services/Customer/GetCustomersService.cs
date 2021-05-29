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

namespace GarageManager.Application.Services.Customer
{
    public class GetCustomersService : IRequest<PagedResponse<IEnumerable<CustomerModel>>>
    {
        public GetRequestParameter GetRequestParameter { get; set; }
    }

    public class HandleGetCustomerService : IRequestHandler<GetCustomersService, PagedResponse<IEnumerable<CustomerModel>>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly IMapper _mapper;

        public HandleGetCustomerService(ICustomerRepositoryAsync customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<CustomerModel>>> Handle(GetCustomersService request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetPagedReponseAsync(request.GetRequestParameter.PageNumber, request.GetRequestParameter.PageSize);
            var customersModels = _mapper.Map<IEnumerable<CustomerModel>>(customers);
            return new PagedResponse<IEnumerable<CustomerModel>>(customersModels, request.GetRequestParameter.PageNumber, request.GetRequestParameter.PageSize);
        }
    }
}
