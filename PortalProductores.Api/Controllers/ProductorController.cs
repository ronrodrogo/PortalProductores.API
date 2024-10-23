using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.Productores.Commands;
using PortalProductores.Application.Feature.Productores.Queries;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductorController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Productor>> GetAllProductoresPadresAsync()
        {
            return await _mediator.Send(
                new GetAllProductoresPadresQuery()
            );
        }

        [HttpGet("{productorPadreId}")]
        public async Task<IEnumerable<Productor>> GetProductoresHijosByProductorPadreIdAsync(
            int productorPadreId
        )
        {
            return await _mediator.Send(
                new GetProductoresHijosByProductorPadreIdQuery(productorPadreId)
            );
        }

        [HttpPost("paginado")]
        public async Task<PaginationResultDto<ProductorPaginationDto>> GetProductoresAsync(
            [FromBody] ProductoresPaginadosCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        public async Task DeleteProductorByIdAsyync(
            DeleteProductorByIdCommand command
        )
        {
            await _mediator.Send(command);
        }
    }
}
