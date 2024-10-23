using MediatR;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public class DeleteUsuarioByIdCommandHandler(
        UsuarioService _usuarioService
    ) : AsyncRequestHandler<DeleteUsuarioByIdCommand>
    {
        protected override async Task Handle(
            DeleteUsuarioByIdCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _usuarioService.DeleteUsuarioByIdAsync(command.UsuarioId);
        }
    }
}
