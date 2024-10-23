using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Recepciones.Commands
{
    public class RecepcionesPaginadosCommandHandler(
        PaginationService _paginationService
    ) : IRequestHandler<RecepcionesPaginadosCommand, PaginationResultDto<RecepcionPaginationDto>>
    {
        public async Task<PaginationResultDto<RecepcionPaginationDto>> Handle(
            RecepcionesPaginadosCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _paginationService.GetDataPaginatedAsync<RecepcionPaginationDto>(
                ItemQueryConstants.GetListRecepciones.GetDescription(),
                ItemQueryConstants.GetCountRecepciones.GetDescription(),
                command.Filter
            );
        }
    }
}
