using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public class ActualizarUsuarioCommandHandler(
        UsuarioService _usuarioService,
        UsuarioProductorService _usuarioProductorService
    ) : IRequestHandler<ActualizarUsuarioCommand, UsuarioConProductoresDto>
    {
        public async Task<UsuarioConProductoresDto> Handle(
            ActualizarUsuarioCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            Usuario usuario = new()
            {
                Id = command.Usuario.Id,
                Nombre = command.Usuario.Nombre,
                Correo = command.Usuario.Correo,
                Telefono = command.Usuario.Telefono,
                Rut = command.Usuario.Rut,
                Perfil = command.Usuario.Perfil,
                Contrasena = command.Usuario.Contrasena,
                UsuarioProductores = command.Usuario.Productores?.Select(productorId => new UsuarioProductor
                {
                    ProductorId = productorId
                }).ToList() ?? []
            };

            usuario = await _usuarioService.ActualizarUsuarioAsync(usuario);

            IEnumerable<UsuarioProductorDto> listUsuarioProductor = await _usuarioProductorService
                .GetListUsuarioProductorByUsuarioIdAsync(usuario.Id);

            return new(usuario, listUsuarioProductor);
        }
    }
}
