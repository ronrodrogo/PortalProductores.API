using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Especies.Queries;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EspecieController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Especie>> GetAllAsync()
        {
            return await _mediator.Send(
                new GetAllEspeciesQuery()
            );
        }
    }
}
