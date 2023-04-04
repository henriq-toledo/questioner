using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Contexts;
using Questioner.WebApi.Services;

namespace Questioner.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();

            switch (appSettings.DatabaseConnector.ToLower())
            {
                case "sqlite":

                    serviceCollection.AddDbContext<ContextForSqlite>
                        (options => options.UseSqlite(configuration.GetConnectionString("ConnectionStringForSqlite")));

                    serviceCollection.AddScoped<IContextService, ContextForSqliteService>();

                    break;

                case "sqlserver":

                    serviceCollection.AddDbContext<ContextForSqlServer>
                        (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

                    serviceCollection.AddScoped<IContextService, ContextForSqlServerService>();

                    break;

                default: throw new NotSupportedException($"The Database Connection '{appSettings.DatabaseConnector}' is not supported.");
            }
        }
    }
}
