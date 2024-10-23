using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Variedades.Queries;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class VariedadController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Variedad>> GetAllAsync()
        {
            return await _mediator.Send(
                new GetAllVariedadesQuery()
            );
        }
    }
}
