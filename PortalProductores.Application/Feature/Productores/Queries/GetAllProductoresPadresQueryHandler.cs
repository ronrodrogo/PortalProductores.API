using MediatR;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Productores.Queries
{
    public class GetAllProductoresPadresQueryHandler(
        ProductorService _productorService
    ) : IRequestHandler<GetAllProductoresPadresQuery, IEnumerable<Productor>>
    {
        public async Task<IEnumerable<Productor>> Handle(
            GetAllProductoresPadresQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _productorService.GetAllProductoresPadresAsync();
        }
    }
}
