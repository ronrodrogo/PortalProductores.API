using MediatR;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Especies.Queries
{
    public class GetAllEspeciesQueryHandler(
        EspecieService _especieService
    ) : IRequestHandler<GetAllEspeciesQuery, IEnumerable<Especie>>
    {
        public async Task<IEnumerable<Especie>> Handle(
            GetAllEspeciesQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _especieService.GetEspeciesAsync();
        }
    }
}
