using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public class UsuariosPaginadosCommandHandler(
        PaginationService _paginationService
    ) : IRequestHandler<UsuariosPaginadosCommand, PaginationResultDto<UsuarioPaginationDto>>
    {
        public async Task<PaginationResultDto<UsuarioPaginationDto>> Handle(
            UsuariosPaginadosCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _paginationService.GetDataPaginatedAsync<UsuarioPaginationDto>(
                ItemQueryConstants.GetListUsuarios.GetDescription(),
                ItemQueryConstants.GetCountUsuarios.GetDescription(),
                command.Filter
            );
        }
    }
}
