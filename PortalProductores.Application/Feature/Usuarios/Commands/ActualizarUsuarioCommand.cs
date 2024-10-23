using MediatR;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public record ActualizarUsuarioCommand(
        UsuarioRequestUpdateDto Usuario
    ) : IRequest<UsuarioConProductoresDto>;
}
