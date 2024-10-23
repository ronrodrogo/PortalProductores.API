using MediatR;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public class ActualizarContrasenaUsuarioCommandHandler(
        UsuarioService _usuarioService
    ) : AsyncRequestHandler<ActualizarContrasenaUsuarioCommand>
    {
        protected override async Task Handle(
            ActualizarContrasenaUsuarioCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _usuarioService.ActualizarContrasenaUsuarioAsync(
                command.UsuarioId,
                command.Contrasena
            );
        }
    }
}
