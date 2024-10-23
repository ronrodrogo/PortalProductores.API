using MediatR;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Application.Feature.Centros.Queries
{
    public record GetAllCentrosQuery : IRequest<IEnumerable<Centro>>;
}
