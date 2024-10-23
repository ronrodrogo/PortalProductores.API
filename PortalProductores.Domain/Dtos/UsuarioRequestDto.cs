namespace PortalProductores.Domain.Dtos
{
    public class UsuarioRequestDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string Rut { get; set; } = string.Empty;
        public byte Perfil { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public IEnumerable<int> Productores { get; set; } = default!;
    }
}
