using MediatR;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Application.Feature.Variedades.Queries
{
    public record GetAllVariedadesQuery : IRequest<IEnumerable<Variedad>>;
}
