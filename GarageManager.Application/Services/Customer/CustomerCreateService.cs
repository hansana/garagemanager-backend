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

namespace GarageManager.Application.Services.Customer
{
    public class CustomerCreateService : IRequest<Response<CustomerModel>>
    {
        public CustomerModel CustomerModel { get; set; }
    }

    public class CustomerCreateServiceHandler : IRequestHandler<CustomerCreateService, Response<CustomerModel>>
    {
        private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
        private readonly IMapper _mapper;

        public CustomerCreateServiceHandler(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
        {
            _customerRepositoryAsync = customerRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<CustomerModel>> Handle(CustomerCreateService request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepositoryAsync.AddAsync(_mapper.Map<Domain.DataModels.Customer>(request.CustomerModel));

            return new Response<CustomerModel>(_mapper.Map<CustomerModel>(customer));
        }
    }
}
