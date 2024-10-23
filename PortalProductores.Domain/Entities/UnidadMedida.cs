namespace PortalProductores.Domain.Entities
{
    public class UnidadMedida
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public byte Estado { get; set; }

        public virtual IEnumerable<Proceso> Procesos { get; set; } = default!;
    }
}
