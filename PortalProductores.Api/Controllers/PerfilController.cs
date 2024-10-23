using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Usuarios.Commands;
using PortalProductores.Application.Feature.Usuarios.Queries;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PerfilController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<UsuarioDto> GetPerfilByTokenAsync()
        {
            return await _mediator.Send(
                new GetUsuarioByTokenQuery(Request.Headers.Authorization.ToString())
            );
        }

        [HttpPatch]
        public async Task ActualizarContrasenaUsuarioAsync(
            [FromBody] ActualizarContrasenaUsuarioCommand command
        )
        {
            await _mediator.Send(command);
        }
    }
}
