using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Ports;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Login.Commands
{
    public class LoginCommandHandler(
        UsuarioService _usuarioService,
        IJwtGenerator _jwtGenerator
    ) : IRequestHandler<LoginCommand, AccesTokenDto>
    {
        public async Task<AccesTokenDto> Handle(
            LoginCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            Domain.Entities.Usuario usuario = await _usuarioService.GetUsuarioByCorreoYContrasenaAsync(
                command.Correo,
                command.Contrasena
            );

            return new(_jwtGenerator.GenerateToken(usuario));
        }
    }
}
