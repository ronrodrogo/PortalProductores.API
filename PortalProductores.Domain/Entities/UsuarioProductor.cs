namespace PortalProductores.Domain.Entities
{
    public class UsuarioProductor
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProductorId { get; set; }

        public virtual Usuario Usuario { get; set; } = default!;
        public virtual Productor Productor { get; set; } = default!;
    }
}
