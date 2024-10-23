namespace PortalProductores.Domain.Dtos
{
    public class ProcesoPaginationDto
    {
        public int? ProductorPadreId { get; set; }
        public string? ProductorPadreNombre { get; set; }
        public int ProductorId { get; set; }
        public string ProductorNombre { get; set; } = string.Empty;
        public int VariedadId { get; set; }
        public string VariedadNombre { get; set; } = string.Empty;
        public string Lote { get; set; } = string.Empty;
        public DateTime? FechaProceso { get; set; }
        public int CentroId { get; set; }
        public string CentroNombre { get; set; } = string.Empty;
        public double? KilosProcesados { get; set; }
        public double? PorcentajeExportacion { get; set; }
        public int TemporadaId { get; set; }
        public int EspecieId { get; set; }
    }
}
