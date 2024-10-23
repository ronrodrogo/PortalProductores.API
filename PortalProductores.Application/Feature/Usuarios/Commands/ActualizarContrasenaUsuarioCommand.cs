using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public record ActualizarContrasenaUsuarioCommand(
        [Required] int UsuarioId,
        [Required] string Contrasena
    ) : IRequest;
}
