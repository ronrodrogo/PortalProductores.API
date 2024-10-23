using MediatR;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Productores.Commands
{
    public class DeleteProductorByIdCommandHandler(
        ProductorService _productorService
    ) : AsyncRequestHandler<DeleteProductorByIdCommand>
    {
        protected override async Task Handle(
            DeleteProductorByIdCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _productorService.DeleteProductorByIdAsyync(command.ProductorId);
        }
    }
}
