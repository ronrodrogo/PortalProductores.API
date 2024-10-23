using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Exceptions;
using PortalProductores.Domain.Helpers;
using PortalProductores.Domain.Ports;

namespace PortalProductores.Domain.Services
{
    [DomainService]
    public class PaginationService(
        IQueryDapper _queryDapper
    )
    {
        public async Task<PaginationResultDto<T>> GetDataPaginatedAsync<T>(
            string query,
            string queryCount,
            PaginationDto filter
        )
        {
            filter.ValidateNullObject(MessagesExceptions.FilterNull);

            var result = await _queryDapper.GetPagedResultsAsync<T>(
                query,
                queryCount,
                filter
            );

            return new()
            {
                Items = result.Item1,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = result.Item2
            };
        }
    }
}
