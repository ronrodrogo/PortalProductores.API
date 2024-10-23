﻿namespace PortalProductores.Domain.Dtos
{
    public class PaginationResultDto<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; } = default!;
    }
}
