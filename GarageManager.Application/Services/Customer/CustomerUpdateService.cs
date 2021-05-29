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
    public class CustomerUpdateService : IRequest<Response<bool>>
    {
        public CustomerModel CustomerModel { get; set; }
    }

    public class CustomerUpdateServiceHandler : IRequestHandler<CustomerUpdateService, Response<bool>>
    {
        private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
        private readonly IMapper _mapper;

        public CustomerUpdateServiceHandler(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
        {
            _customerRepositoryAsync = customerRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CustomerUpdateService request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepositoryAsync.GetByIdAsync(request.CustomerModel.Id);
            if (customer == null)
            {
                return new Response<bool>
                {
                    Message = "Customer not found",
                    Succeeded = false,
                    Status = ResponseStatus.NotFound
                };
            }

            customer.FirstName = request.CustomerModel.FirstName;
            customer.LastName = request.CustomerModel.LastName;
            customer.Email = request.CustomerModel.Email;
            customer.Address = request.CustomerModel.Address;
            customer.MobileNumber = request.CustomerModel.MobileNumber;
            customer.HomeNumber = request.CustomerModel.HomeNumber;

            await _customerRepositoryAsync.UpdateAsync(customer);

            return new Response<bool>(true);
        }
    }
}
