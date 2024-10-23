using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public record DeleteUsuarioByIdCommand(
        [Required] int UsuarioId
    ) : IRequest;
}
