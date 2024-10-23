using MediatR;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Centros.Queries
{
    public class GetAllCentrosQueryHandler(
        CentroService _centroService
    ) : IRequestHandler<GetAllCentrosQuery, IEnumerable<Centro>>
    {
        public async Task<IEnumerable<Centro>> Handle(
            GetAllCentrosQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _centroService.GetCentrosAsync();
        }
    }
}
