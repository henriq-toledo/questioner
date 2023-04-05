using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Questioner.WebApp.Mappers;
using Questioner.WebApp.Repositories;
using Questioner.WebApp.Services;
using Questioner.WebApp.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Questioner.WebApp
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<QuestionerWebApiSettings>(options => Configuration.GetSection(nameof(QuestionerWebApiSettings)).Bind(options));

            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<IResultService, ResultService>();
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IQuestionerWebApiService, QuestionerWebApiService>();
            services.AddScoped<IReportExportService, ReportExportService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            ILogger<Startup> logger,
            IOptions<QuestionerWebApiSettings> options)
        {
            logger.LogInformation($"Environment: '{env.EnvironmentName}'.");
            logger.LogInformation($"Questioner API url: '{options.Value.Url}'.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
