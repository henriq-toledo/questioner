using Microsoft.Extensions.Options;
using Questioner.WebApp.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Questioner.WebApp
{
    [ExcludeFromCodeCoverage]
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddLog4Net();

            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                startup.Configure(
                    app,
                    app.Environment,
                    services.GetRequiredService<ILogger<Startup>>(),
                    services.GetRequiredService<IOptions<QuestionerWebApiSettings>>());
            }

            app.Run();
        }
    }
}