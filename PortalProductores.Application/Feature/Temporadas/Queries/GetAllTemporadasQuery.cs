using MediatR;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Application.Feature.Temporadas.Queries
{
    public record GetAllTemporadasQuery : IRequest<IEnumerable<Temporada>>;
}
