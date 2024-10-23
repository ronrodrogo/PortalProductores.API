using PortalProductores.Domain.Dtos;

namespace PortalProductores.Domain.Ports
{
    public interface IQueryDapper
    {
        Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription)
            where T : class;

        Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object parameters)
            where T : class;

        Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object parameters, object[]? args)
            where T : class;

        Task<IEnumerable<dynamic>> QueryAsync(string resourceItemDescription, object[]? args);

        Task<T> QuerySingleAsync<T>(string resourceItemDescription, object parameters);

        Task<T> QuerySingleAsync<T>(string resourceItemDescription, object parameters, object[]? args);

        Task ExecuteAsync(string resourceItemDescription, object parameters);

        Task ExecuteAsync(string resourceItemDescription, object parameters, object[]? args);

        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedResultsAsync<T>(
            string baseQueryName,
            string countQueryName,
            PaginationDto filter
        );

        Task<IEnumerable<T>> GetDataExportExcelAsync<T>(
            string baseQueryName,
            IEnumerable<PaginationFilterDto> filters
        );
    }
}
