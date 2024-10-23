using MediatR;
using PortalProductores.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace PortalProductores.Application.Feature.ExportalExcel.Commands
{
    public record ExportarExcelRecepcionesCommand(
        [Required] IEnumerable<PaginationFilterDto> Filters
    ) : IRequest<byte[]>;
}
