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

namespace GarageManager.Application.Services.Customer
{
    public class CustomerByIdService : IRequest<Response<CustomerModel>>
    {
        public Guid Id { get; set; }
    }

    public class CustomerByIdServiceHandler : IRequestHandler<CustomerByIdService, Response<CustomerModel>>
    {
        private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
        private readonly IMapper _mapper;

        public CustomerByIdServiceHandler(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper = null)
        {
            _customerRepositoryAsync = customerRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<CustomerModel>> Handle(CustomerByIdService request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepositoryAsync.GetByIdAsync(request.Id);

            if (customer == null)
            {
                return new Response<CustomerModel>
                {
                    Message = "Customer not found",
                    Succeeded = false,
                    Status = ResponseStatus.NotFound
                };
            }

            return new Response<CustomerModel>(_mapper.Map<CustomerModel>(customer));
        }
    }
}
