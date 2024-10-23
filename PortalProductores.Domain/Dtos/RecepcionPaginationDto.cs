namespace PortalProductores.Domain.Dtos
{
    public class RecepcionPaginationDto
    {
        public int? ProductorPadreId { get; set; }
        public string? ProductorPadreNombre { get; set; }
        public int ProductorId { get; set; }
        public string ProductorNombre { get; set; } = string.Empty;
        public int TemporadaId { get; set; }
        public int EspecieId { get; set; }
        public int VariedadId { get; set; }
        public string VariedadNombre { get; set; } = string.Empty;
        public int Guia { get; set; }
        public int NumeroPartida { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int CantidadEnvases { get; set; }
        public double KilosRecepcionados { get; set; }
        public byte Estado { get; set; }
        public string EstadoDescripcion { get; set; } = string.Empty;
    }
}
