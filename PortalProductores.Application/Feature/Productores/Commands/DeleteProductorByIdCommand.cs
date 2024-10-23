using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Productores.Commands
{
    public record DeleteProductorByIdCommand(
        [Required] int ProductorId
    ) : IRequest;
}
