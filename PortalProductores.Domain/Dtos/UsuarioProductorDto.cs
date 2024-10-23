namespace PortalProductores.Domain.Dtos
{
    public class UsuarioProductorDto
    {
        public int UsuarioId { get; set; }
        public int ProductorId { get; set; }
        public string RutProductor { get; set; } = string.Empty;
        public string NombreProductor { get; set; } = string.Empty;
    }
}
