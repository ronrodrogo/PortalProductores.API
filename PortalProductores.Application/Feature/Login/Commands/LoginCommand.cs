using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Login.Commands
{
    public record LoginCommand(
        [Required] string Correo,
        [Required] string Contrasena
    ) : IRequest<AccesTokenDto>;
}
