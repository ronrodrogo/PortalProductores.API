namespace PortalProductores.Domain.Dtos
{
    public class ProductorPaginationDto
    {
        public int Id { get; set; }
        public string CodigoSAP { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public int? ProductorPadreId { get; set; }
        public string? CodigoSAPPadre { get; set; }
        public string? NombrePadre { get; set; }
        public string? RutPadre { get; set; }
        public string? CorreoPadre { get; set; }
    }
}
