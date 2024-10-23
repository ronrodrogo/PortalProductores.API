using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Services;

namespace PortalProductores.Application.Feature.Usuarios.Queries
{
    public class GetUsuarioByIdQueryHandler(
        UsuarioService _usuarioService,
        UsuarioProductorService _usuarioProductorService
    ) : IRequestHandler<GetUsuarioByIdQuery, UsuarioConProductoresDto>
    {
        public async Task<UsuarioConProductoresDto> Handle(
            GetUsuarioByIdQuery query,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            Usuario usuario = await _usuarioService.GetUsuarioByIdAsync(query.UsuarioId);

            IEnumerable<UsuarioProductorDto> listUsuarioProductor = await _usuarioProductorService
                .GetListUsuarioProductorByUsuarioIdAsync(query.UsuarioId);

            return new(usuario, listUsuarioProductor);
        }
    }
}
