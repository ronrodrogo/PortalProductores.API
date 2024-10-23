using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Centros.Queries;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CentroController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Centro>> GetAllAsync()
        {
            return await _mediator.Send(
                new GetAllCentrosQuery()
            );
        }
    }
}
