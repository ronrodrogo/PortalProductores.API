using MediatR;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Application.Feature.ExportalExcel.Commands
{
    public class ExportarExcelProcesosCommandHandler(
        IQueryDapper _queryDapper,
        IExportExcel _exportExcel
    ) : IRequestHandler<ExportarExcelProcesosCommand, byte[]>
    {
        public async Task<byte[]> Handle(
            ExportarExcelProcesosCommand command,
            CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var headers = new List<string> {
                "ProductorNombre",
                "VariedadNombre",
                "Lote",
                "FechaProceso",
                "CentroNombre",
                "KilosProcesados",
                "PorcentajeExportacion"
            };

            IEnumerable<ProcesoPaginationDto> data = await _queryDapper.GetDataExportExcelAsync<ProcesoPaginationDto>(
                ItemQueryConstants.GetListProcesos.GetDescription(),
                command.Filters
            );

            return await _exportExcel.ExportToExcel(data.ToList(), headers);
        }
    }
}
