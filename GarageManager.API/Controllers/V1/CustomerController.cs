using GarageManager.Application.Parameters;
using GarageManager.Application.Services.Customer;
using GarageManager.Application.Wrappers;
using GarageManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.API.Controllers.V1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {
        /// <summary>
        /// Returns customer List.
        /// </summary>
        /// 
        /// <returns>List of customers</returns>
        /// <response code="200">List of customers</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<CustomerModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<IActionResult> Get(GetRequestParameter parameter)
        {
            return ResolveResponse(await Mediator.Send(new GetCustomersService() { GetRequestParameter = parameter }));
        }

        /// <summary>
        /// Returns customer by ID.
        /// </summary>
        /// 
        /// <param name="id"></param>
        /// <returns>Customer by given ID</returns>
        /// <response code="200">Returns customer by given ID</response>
        /// <response code="404">If the item by ID is not found</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return ResolveResponse(await Mediator.Send(new CustomerByIdService() { Id = id }));
        }

        /// <summary>
        /// Creats a customer record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Customer
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns>A newly created customer</returns>
        /// <response code="201">Returns the newly created customer</response>
        /// <response code="400">If customer is invalid</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<CustomerModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerModel customer)
        {
            var respone = await Mediator.Send(new CustomerCreateService() { CustomerModel = customer });

            return CreatedAtAction(nameof(Get), new { id = respone.Data.Id }, respone.Data);
        }

        /// <summary>
        /// Update a customer record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /Customer
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns>Returns true if updated successfully</returns>
        /// <response code="201">Returns true if customer updated</response>
        /// <response code="400">If customer is invalid</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<CustomerModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerModel customer)
        {
            return ResolveResponse(await Mediator.Send(new CustomerUpdateService() { CustomerModel = customer }));
        }

        /// <summary>
        /// Update a customer record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Customer
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <response code="204">If customer updated successfully</response>
        /// <response code="400">If customer is invalid</response>
        /// <response code="404">If customer is not found</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CustomerModel customer)
        {
            //await _customerService.UpdateCustomer(id, customer);

            return NoContent();
        }
    }
}
