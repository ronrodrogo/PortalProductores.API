namespace PortalProductores.Domain.Entities
{
    public class Temporada
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte Estado { get; set; }

        public virtual IEnumerable<Recepcion> Recepciones { get; set; } = default!;
        public virtual IEnumerable<Proceso> Procesos { get; set; } = default!;
    }
}
