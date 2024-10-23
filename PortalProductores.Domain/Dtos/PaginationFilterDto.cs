namespace PortalProductores.Domain.Dtos
{
    public class PaginationFilterDto
    {
        public string? FiltrarPor { get; set; }
        public string TextoBusqueda { get; set; } = string.Empty;
        public bool IsLike { get; set; }
    }
}
