using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Usuarios.Queries
{
    public record GetUsuarioByTokenQuery(
        [Required] string Token
    ) : IRequest<UsuarioDto>;
}
