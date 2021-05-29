using GarageManager.Application.Services.Admission;
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
    public class AdmissionController : BaseApiController
    {
        /// <summary>
        /// Returns vehicle admission by ID.
        /// </summary>
        /// 
        /// <param name="id"></param>
        /// <returns>Vehicle admission by given ID</returns>
        /// <response code="200">Returns vehicle admission by given ID</response>
        /// <response code="404">If the item by ID is not found</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<VehicleAdmissionModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return ResolveResponse(await Mediator.Send(new AdmissionByIdService() { Id = id }));
        }

        /// <summary>
        /// Creats a vehicle admission record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Admission
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="admission"></param>
        /// <returns>A newly created vehicle admission</returns>
        /// <response code="201">Returns the newly created vehicle admission</response>
        /// <response code="400">If admission is invalid</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<VehicleAdmissionModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehicleAdmissionModel admission)
        {
            var response = await Mediator.Send(new CreateAdmissionService() { VehicleAdmissionModel = admission });

            return CreatedAtAction(nameof(Get), new { id = response.Data.Id }, response.Data);
        }
    }
}
