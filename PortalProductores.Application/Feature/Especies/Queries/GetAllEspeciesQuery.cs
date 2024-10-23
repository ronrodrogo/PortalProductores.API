using MediatR;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Application.Feature.Especies.Queries
{
    public record GetAllEspeciesQuery : IRequest<IEnumerable<Especie>>;
}
