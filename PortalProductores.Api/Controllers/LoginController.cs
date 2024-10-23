using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Login.Commands;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<AccesTokenDto> GetLoginAsync(
            [FromBody] LoginCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpPost("example")]
        public async Task Example()
        {
            Console.WriteLine("opa");
        }
    }
}
