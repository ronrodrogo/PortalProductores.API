namespace PortalProductores.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string Rut { get; set; } = string.Empty;
        public byte Perfil { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual IEnumerable<UsuarioProductor> UsuarioProductores { get; set; } = default!;
    }
}
