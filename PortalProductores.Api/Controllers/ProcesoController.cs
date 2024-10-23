using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Procesos.Commands;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProcesoController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpPost("paginado")]
        public async Task<PaginationResultDto<ProcesoPaginationDto>> GetProcesosAsync(
            [FromBody] ProcesosPaginadosCommand command
        )
        {
            return await _mediator.Send(command);
        }
    }
}
