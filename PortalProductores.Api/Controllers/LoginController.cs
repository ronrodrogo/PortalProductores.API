using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PortalProductores.Application.Feature.Login.Commands;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoginController(
        IMediator _mediator,
        IConfiguration configuration
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<AccesTokenDto> GetLoginAsync(
            [FromBody] LoginCommand command
        )
        {
            return await _mediator.Send(command);
        }

        [HttpPost("example")]
        public async Task<IActionResult> Example()
        {
           IConfiguration _configuration = configuration;
            Console.WriteLine("opa");
            // Cadena de conexión desde el appsettings.json o las variables de entorno
            var connectionString = _configuration.GetConnectionString("Database");

            try
            {
                // Intentamos abrir una conexión a la base de datos
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                    return Ok("Conexión exitosa a la base de datos.");
                }
            }
            catch (Exception ex)
            {
                // Si hay un error, lo capturamos y devolvemos una respuesta con el error
                Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                return StatusCode(500, $"Error al conectar con la base de datos: {ex.Message}");
            }
        }
    }
}
