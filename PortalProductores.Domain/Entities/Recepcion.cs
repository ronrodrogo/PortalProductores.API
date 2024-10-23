namespace PortalProductores.Domain.Entities
{
    public class Recepcion
    {
        public int Id { get; set; }
        public int ProductorId { get; set; }
        public int TemporadaId { get; set; }
        public string? Uat { get; set; }
        public int VariedadId { get; set; }
        public int CentroId { get; set; }
        public int? Guia { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int EspecieId { get; set; }
        public DateTime? FechaCosecha { get; set; }
        public int? NumeroPartida { get; set; }
        public double KilosRecepcionados { get; set; }
        public int? CantidadEnvases { get; set; }
        public DateTime FechaCreacion { get; set; }
        public byte Estado { get; set; }

        public virtual Productor Productor { get; set; } = default!;
        public virtual Temporada Temporada { get; set; } = default!;
        public virtual Variedad Variedad { get; set; } = default!;
        public virtual Centro Centro { get; set; } = default!;
        public virtual Especie Especie { get; set; } = default!;
    }
}
