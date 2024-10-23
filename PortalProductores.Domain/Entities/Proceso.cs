namespace PortalProductores.Domain.Entities
{
    public class Proceso
    {
        public int Id { get; set; }
        public int ProductorId { get; set; }
        public int VariedadId { get; set; }
        public int CentroId { get; set; }
        public string Lote { get; set; } = string.Empty;
        public DateTime? FechaProduccion { get; set; }
        public double? KilosExportables { get; set; }
        public double? PorcentajeExportacion { get; set; }
        public double? KilosComerciales { get; set; }
        public double? PorcentajeComercial { get; set; }
        public double? KilosProcesados { get; set; }
        public int TemporadaId { get; set; }
        public int EspecieId { get; set; }
        public DateTime? FechaProceso { get; set; }
        public int PlantaId { get; set; }
        public string? Resultado { get; set; }
        public string? Tamano { get; set; }
        public string? Condicion { get; set; }
        public double? CantidadExportable { get; set; }
        public int UnidadMedidaId { get; set; }
        public double? KilosDescarte { get; set; }

        public virtual Productor Productor { get; set; } = default!;
        public virtual Variedad Variedad { get; set; } = default!;
        public virtual Centro Centro { get; set; } = default!;
        public virtual Temporada Temporada { get; set; } = default!;
        public virtual Especie Especie { get; set; } = default!;
        public virtual Planta Planta { get; set; } = default!;
        public virtual UnidadMedida UnidadMedida { get; set; } = default!;
    }
}
