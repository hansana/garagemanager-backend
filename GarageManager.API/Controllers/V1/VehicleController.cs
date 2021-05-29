using GarageManager.Application.Parameters;
using GarageManager.Application.Services.Vehicle;
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
    public class VehicleController : BaseApiController
    {
        /// <summary>
        /// Returns vehicle List.
        /// </summary>
        /// 
        /// <returns>List of vehicles</returns>
        /// <response code="200">List of vehicles</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<VehicleModel>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetVehicleParameter parameter)
        {
            return ResolveResponse(await Mediator.Send(new GetVehiclesService() { VehicleParameter = parameter }));
        }

        /// <summary>
        /// Returns vehicle by ID.
        /// </summary>
        /// 
        /// <param name="id"></param>
        /// <returns>Vehicle by given ID</returns>
        /// <response code="200">Returns vehicle by given ID</response>
        /// <response code="404">If the item by ID is not found</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<VehicleModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return ResolveResponse(await Mediator.Send(new GetVehicleByIdService() { Id = id }));
        }

        /// <summary>
        /// Creats a vehicle record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Vehicle
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="vehicle"></param>
        /// <returns>A newly created vehicle</returns>
        /// <response code="201">Returns the newly created vehicle</response>
        /// <response code="400">If vehicle is invalid</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<VehicleModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleModel vehicle)
        {
            var response = await Mediator.Send(new CreateVehicleService() { VehicleModel = vehicle });
            
            return CreatedAtAction(nameof(Get), new { id = response.Data.Id }, response.Data);
        }

        /// <summary>
        /// Update a vehicle record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Vehicle
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="vehicle"></param>
        /// <response code="204">If vehicle updated successfully</response>
        /// <response code="400">If vehicle is invalid</response>
        /// <response code="404">If vehicle is not found</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] VehicleModel vehicle)
        {
            //await _vehicleService.UpdateVehicle(id, vehicle);

            return NoContent();
        }
    }
}
