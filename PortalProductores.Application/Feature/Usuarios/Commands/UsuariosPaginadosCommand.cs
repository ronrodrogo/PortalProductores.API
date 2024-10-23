using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Usuarios.Commands
{
    public record UsuariosPaginadosCommand(
        [Required] PaginationDto Filter
    ) : IRequest<PaginationResultDto<UsuarioPaginationDto>>;
}
