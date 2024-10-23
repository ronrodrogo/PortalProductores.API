using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Productores.Commands
{
    public record ProductoresPaginadosCommand(
        [Required] PaginationDto Filter
    ) : IRequest<PaginationResultDto<ProductorPaginationDto>>;
}
