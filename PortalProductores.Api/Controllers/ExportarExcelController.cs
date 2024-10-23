using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalProductores.Application.Feature.ExportalExcel.Commands;

namespace PortalProductores.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ExportarExcelController(
        IMediator _mediator
    ) : ControllerBase
    {
        [HttpPost("recepciones")]
        public async Task<IActionResult> ExportarExcelRecepcionesAsync(
            [FromBody] ExportarExcelRecepcionesCommand command
        )
        {
            var file = await _mediator.Send(command);

            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reporteRecepciones.xlsx");
        }

        [HttpPost("procesos")]
        public async Task<IActionResult> ExportarExcelProcesosAsync(
            [FromBody] ExportarExcelProcesosCommand command
        )
        {
            var file = await _mediator.Send(command);

            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reporteProcesos.xlsx");
        }
    }
}
