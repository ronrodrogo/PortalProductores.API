using MediatR;
using PortalProductores.Domain.Entities;

namespace PortalProductores.Application.Feature.Productores.Queries
{
    public class GetAllProductoresPadresQuery : IRequest<IEnumerable<Productor>>;
}
