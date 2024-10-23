namespace PortalProductores.Domain.Dtos
{
    public class UsuarioPaginationDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string TipoPerfil { get; set; } = string.Empty;
    }
}
