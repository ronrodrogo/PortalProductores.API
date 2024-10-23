using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Recepciones.Commands
{
    public record RecepcionesPaginadosCommand(
        [Required] PaginationDto Filter
    ) : IRequest<PaginationResultDto<RecepcionPaginationDto>>;
}
