using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalProductores.Domain.Ports;
using PortalProductores.Infrastructure.Adapters;
using System.Data;

namespace PortalProductores.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IQueryDapper), typeof(QueryDapper));
            services.AddTransient(typeof(IJwtGenerator), typeof(JwtGenerator));
            services.AddTransient(typeof(IExportExcel), typeof(ExportExcel));
            services.AddTransient<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("Database")));

            return services;
        }
    }
}
