using MediatR;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Temporadas.Queries
{
    public class GetAllTemporadasQueryHandler(
        TemporadaService _temporadaService
    ) : IRequestHandler<GetAllTemporadasQuery, IEnumerable<Temporada>>
    {
        public async Task<IEnumerable<Temporada>> Handle(
            GetAllTemporadasQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _temporadaService.GetTemporadasAsync();
        }
    }
}
