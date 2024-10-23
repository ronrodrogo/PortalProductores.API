using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Temporadas.Queries;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TemporadaController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Temporada>> GetAllAsync()
        {
            return await _mediator.Send(
                new GetAllTemporadasQuery()
            );
        }
    }
}
