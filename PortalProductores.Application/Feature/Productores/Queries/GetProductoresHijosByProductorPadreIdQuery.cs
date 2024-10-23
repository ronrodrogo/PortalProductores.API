using MediatR;
using PortalProductores.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.Productores.Queries
{
    public record GetProductoresHijosByProductorPadreIdQuery(
        [Required] int ProductorPadreId
    ) : IRequest<IEnumerable<Productor>>;
}
