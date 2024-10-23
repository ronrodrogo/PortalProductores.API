namespace PortalProductores.Domain.Entities
{
    public class Productor
    {
        public int Id { get; set; }
        public int? ProductorPadreId { get; set; }
        public string? CodigoSAP { get; set; }
        public string? CodigoCSG { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string? RazonSocial { get; set; }
        public byte TipoProductor { get; set; }
        public string? Provincia { get; set; }
        public string? Comuna { get; set; }
        public string Pais { get; set; } = string.Empty;
        public string? CodigoRegion { get; set; }
        public bool Bloqueado { get; set; }
        public bool Prospecto { get; set; }
        public byte TipoContrato { get; set; }
        public string? CentroEmbalaje { get; set; }
        public string? CorreoAvisoProceso { get; set; }
        public string? CorreoInformeProceso { get; set; }
        public string? CorreoInformeRecepcion { get; set; }
        public byte Estado { get; set; }

        public virtual IEnumerable<UsuarioProductor> UsuarioProductores { get; set; } = default!;
        public virtual IEnumerable<Recepcion> Recepciones { get; set; } = default!;
        public virtual IEnumerable<Proceso> Procesos { get; set; } = default!;
    }
}
