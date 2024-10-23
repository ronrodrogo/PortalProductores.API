using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Application.Feature.ExportalExcel.Commands
{
    public class ExportarExcelRecepcionesCommandHandler(
        IQueryDapper _queryDapper,
        IExportExcel _exportExcel
    ) : IRequestHandler<ExportarExcelRecepcionesCommand, byte[]>
    {
        public async Task<byte[]> Handle(
            ExportarExcelRecepcionesCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var headers = new List<string> {
                "ProductorNombre",
                "VariedadNombre",
                "Guia",
                "NumeroPartida",
                "FechaRecepcion",
                "CantidadEnvases",
                "KilosRecepcionados",
                "Estado"
            };

            IEnumerable<RecepcionPaginationDto> data = await _queryDapper.GetDataExportExcelAsync<RecepcionPaginationDto>(
                ItemQueryConstants.GetListRecepciones.GetDescription(),
                command.Filters
            );

            return await _exportExcel.ExportToExcel(data.ToList(), headers);
        }
    }
}
