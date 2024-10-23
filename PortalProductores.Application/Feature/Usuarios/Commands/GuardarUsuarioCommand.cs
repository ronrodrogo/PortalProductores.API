using MediatR;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public record GuardarUsuarioCommand(
        UsuarioRequestDto Usuario
    ) : IRequest<UsuarioConProductoresDto>;
}
