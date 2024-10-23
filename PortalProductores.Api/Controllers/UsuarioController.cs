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
    public class UsuarioController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet("{usuarioId}")]
        public async Task<UsuarioConProductoresDto> GetUsuarioByIdAsync(int usuarioId)
        {
            return await _mediator.Send(
                new GetUsuarioByIdQuery(usuarioId)
            );
        }

        [HttpPost]
        public async Task<UsuarioConProductoresDto> GuardarUsuarioAsync(
            [FromBody] GuardarUsuarioCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpPost("paginado")]
        public async Task<PaginationResultDto<UsuarioPaginationDto>> GetUsuariosAsync(
            [FromBody] UsuariosPaginadosCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<UsuarioConProductoresDto> ActualizarUsuarioAsync(
            [FromBody] ActualizarUsuarioCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteUsuarioByIdAsync(
            DeleteUsuarioByIdCommand command
        )
        {
            await _mediator.Send(command);
        }
    }
}
