using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Productores.Commands
{
    public class ProductoresPaginadosCommandHandler(
        PaginationService _paginationService
    ) : IRequestHandler<ProductoresPaginadosCommand, PaginationResultDto<ProductorPaginationDto>>
    {
        public async Task<PaginationResultDto<ProductorPaginationDto>> Handle(
            ProductoresPaginadosCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _paginationService.GetDataPaginatedAsync<ProductorPaginationDto>(
                ItemQueryConstants.GetListProductores.GetDescription(),
                ItemQueryConstants.GetCountProductores.GetDescription(),
                command.Filter
            );
        }
    }
}
