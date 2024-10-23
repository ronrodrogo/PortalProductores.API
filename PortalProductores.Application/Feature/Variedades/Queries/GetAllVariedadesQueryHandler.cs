using MediatR;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Variedades.Queries
{
    public class GetAllVariedadesQueryHandler(
        VariedadService _variedadService
    ) : IRequestHandler<GetAllVariedadesQuery, IEnumerable<Variedad>>
    {
        public async Task<IEnumerable<Variedad>> Handle(
            GetAllVariedadesQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _variedadService.GetVariedadesAsync();
        }
    }
}
