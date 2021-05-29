using GarageManager.Application.Enums;
using GarageManager.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace GarageManager.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult ResolveResponse<Tin>(Response<Tin> response)
        {
            switch (response.Status)
            {
                case ResponseStatus.OK:
                    return Ok(response);
                case ResponseStatus.NotFound:
                    return NotFound(response);
                case ResponseStatus.NoContent:
                    return NoContent();
                default:
                    return BadRequest(response);

            }
        }
    }
}
