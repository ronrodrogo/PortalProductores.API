using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Procesos.Commands
{
    public class ProcesosPaginadosCommandHandler(
        PaginationService _paginationService
    ) : IRequestHandler<ProcesosPaginadosCommand, PaginationResultDto<ProcesoPaginationDto>>
    {
        public async Task<PaginationResultDto<ProcesoPaginationDto>> Handle(
            ProcesosPaginadosCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _paginationService.GetDataPaginatedAsync<ProcesoPaginationDto>(
                ItemQueryConstants.GetListProcesos.GetDescription(),
                ItemQueryConstants.GetCountProcesos.GetDescription(),
                command.Filter
            );
        }
    }
}
