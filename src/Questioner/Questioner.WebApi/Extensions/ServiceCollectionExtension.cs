using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Questioner.Repository.Classes.Entities;
using System;

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

                    serviceCollection.AddDbContext<Context>
                        (options => options.UseSqlite(configuration.GetConnectionString("ConnectionStringForSqlite")))
                        .AddScoped<Context>();

                    break;

                case "sqlserver":

                    serviceCollection.AddDbContext<Context>
                    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")))
                    .AddScoped<Context>();

                    break;

                default: throw new Exception($"The Database Connection '{appSettings.DatabaseConnector}' is not supported.");
            }
        }
    }
}
