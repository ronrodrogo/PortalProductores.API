using MediatR;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Productores.Queries
{
    public class GetProductoresHijosByProductorPadreIdQueryHandler(
        ProductorService _productorService
    ) : IRequestHandler<GetProductoresHijosByProductorPadreIdQuery, IEnumerable<Productor>>
    {
        public async Task<IEnumerable<Productor>> Handle(
            GetProductoresHijosByProductorPadreIdQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _productorService
                .GetProductoresHijosByProductorPadreIdAsync(query.ProductorPadreId);
        }
    }
}
