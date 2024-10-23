using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Recepciones.Commands;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class RecepcionController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpPost("paginado")]
        public async Task<PaginationResultDto<RecepcionPaginationDto>> GetRecepcionesAsync(
            [FromBody] RecepcionesPaginadosCommand command
        )
        {
            return await _mediator.Send(command);
        }
    }
}
