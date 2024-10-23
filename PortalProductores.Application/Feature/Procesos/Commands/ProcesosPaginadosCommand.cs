using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Procesos.Commands
{
    public record ProcesosPaginadosCommand(
        [Required] PaginationDto Filter
    ) : IRequest<PaginationResultDto<ProcesoPaginationDto>>;
}
