using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Ports;
using PortalProductores.Domain.Services;
using System.Security.Claims;

namespace PortalProductores.Application.Feature.Usuarios.Queries
{
    public class GetUsuarioByTokenQueryHandler(
        UsuarioService _usuarioService,
        IJwtGenerator _jwtGenerator
    ) : IRequestHandler<GetUsuarioByTokenQuery, UsuarioDto>
    {
        public async Task<UsuarioDto> Handle(
            GetUsuarioByTokenQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            ClaimsPrincipal claims = _jwtGenerator.DeserializeToken(query.Token);

            Usuario usuario = await _usuarioService.GetUsuarioByCorreoAsync(
                claims.FindFirst("Correo")!.Value
            );

            return new(usuario);
        }
    }
}
