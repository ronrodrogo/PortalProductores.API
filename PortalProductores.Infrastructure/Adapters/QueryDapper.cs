using Dapper;
using Microsoft.Data.SqlClient;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Exceptions;
using PortalProductores.Domain.Ports;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;

namespace PortalProductores.Infrastructure.Adapters
{
    public class QueryDapper(IDbConnection connection) : IQueryDapper
    {
        private readonly IDbConnection _connection = connection;
        private readonly ComponentResourceManager _componentResourceManager = new(typeof(Constants.QueryConstants));

        public async Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription)
            where T : class
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QueryAsync<T>(query);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object parameters)
            where T : class
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QueryAsync<T>(query, parameters);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string resourceItemDescription, object parameters, object[]? args)
            where T : class
        {
            string query = GetQuery(resourceItemDescription, args);

            return await _connection.QueryAsync<T>(query, parameters);
        }

        public Task<IEnumerable<dynamic>> QueryAsync(string resourceItemDescription, object[]? args)
        {
            string query = GetQuery(resourceItemDescription, args);

            return _connection.QueryAsync(query);
        }

        public async Task<T> QuerySingleAsync<T>(string resourceItemDescription, object parameters)
        {
            string query = GetQuery(resourceItemDescription);

            return await _connection.QuerySingleOrDefaultAsync<T>(query, parameters);
        }

        public async Task<T> QuerySingleAsync<T>(string resourceItemDescription, object parameters, object[]? args)
        {
            try
            {
                string query = GetQuery(resourceItemDescription, args);

                return await _connection.QuerySingleOrDefaultAsync<T>(query, parameters);
            }
            catch (SqlException ex)
            {
                throw new TimeoutErrorException(ex.Message, ex.InnerException!);
            }
        }

        public async Task ExecuteAsync(string resourceItemDescription, object parameters)
        {
            string query = GetQuery(resourceItemDescription);

            await _connection.ExecuteAsync(query, parameters);
        }

        public async Task ExecuteAsync(string resourceItemDescription, object parameters, object[]? args)
        {
            string query = GetQuery(resourceItemDescription, args);

            await _connection.ExecuteAsync(query, parameters);
        }

        private string GetQuery(string resourceItemDescription, object[]? args = null)
        {
            if (args is null)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    _componentResourceManager.GetString(resourceItemDescription)!
                );
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                _componentResourceManager.GetString(resourceItemDescription)!,
                args!
            );
        }

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedResultsAsync<T>(
            string baseQueryName,
            string countQueryName,
            PaginationDto filter
        )
        {
            StringBuilder baseQuery = new(
                string.Format(
                    CultureInfo.InvariantCulture,
                    _componentResourceManager.GetString(baseQueryName)!
                )
            );

            string countQuery = string.Format(
                CultureInfo.InvariantCulture,
                _componentResourceManager.GetString(countQueryName)!
            );

            BuilderQueryFilter(baseQuery, filter.PaginationFilters);

            var offset = (filter.PageNumber - 1) * filter.PageSize;
            baseQuery.Append(" ORDER BY 1 OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY");

            DynamicParameters parameters = new();
            parameters.Add("Offset", offset);
            parameters.Add("PageSize", filter.PageSize);

            var items = await connection.QueryAsync<T>(baseQuery.ToString(), parameters);
            var totalCount = await connection.ExecuteScalarAsync<int>(countQuery);

            return (items, totalCount);
        }

        public async Task<IEnumerable<T>> GetDataExportExcelAsync<T>(string baseQueryName, IEnumerable<PaginationFilterDto> filters)
        {
            StringBuilder baseQuery = new(
                string.Format(
                    CultureInfo.InvariantCulture,
                    _componentResourceManager.GetString(baseQueryName)!
                )
            );

            BuilderQueryFilter(baseQuery, filters);

            return await connection.QueryAsync<T>(baseQuery.ToString());
        }

        private static void BuilderQueryFilter(
            StringBuilder baseQuery,
            IEnumerable<PaginationFilterDto> filters
        )
        {
            if (filters != null && filters.Any())
            {
                foreach (var item in filters)
                {
                    if (!string.IsNullOrEmpty(item.FiltrarPor) && !string.IsNullOrEmpty(item.TextoBusqueda))
                    {
                        baseQuery.Append(
                            item.IsLike
                                ? $" and {item.FiltrarPor} like '%{item.TextoBusqueda}%'"
                                : $" and {item.FiltrarPor} = '{item.TextoBusqueda}'"
                        );
                    }
                }
            }
        }
    }
}
