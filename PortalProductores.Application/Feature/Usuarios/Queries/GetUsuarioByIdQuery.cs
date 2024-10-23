using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Usuarios.Queries
{
    public record GetUsuarioByIdQuery(
        [Required] int UsuarioId
    ) : IRequest<UsuarioConProductoresDto>;
}
