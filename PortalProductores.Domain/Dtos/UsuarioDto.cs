using PortalProductores.Domain.Entities;
using PortalProductores.Domain.Enums;
using PortalProductores.Domain.Helpers;

namespace PortalProductores.Domain.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public byte Perfil { get; set; }
        public string PerfilDescripcion { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public byte Estado { get; set; }
        public string EstadoDescripcion { get; set; } = string.Empty;

        public UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nombre = usuario.Nombre;
            Correo = usuario.Correo;
            Telefono = usuario.Telefono;
            Rut = usuario.Rut;
            Perfil = usuario.Perfil;
            PerfilDescripcion = ((PerfilTypes)Perfil).GetDescription();
            Contrasena = usuario.Contrasena;
            Estado = usuario.Estado;
            EstadoDescripcion = ((EstadoTypes)Estado).GetDescription();
        }
    }
}
