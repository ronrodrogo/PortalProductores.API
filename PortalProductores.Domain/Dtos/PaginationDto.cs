namespace PortalProductores.Domain.Dtos
{
    public class PaginationDto
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public IEnumerable<PaginationFilterDto> PaginationFilters { get; set; } = default!;
    }
}
