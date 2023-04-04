using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Questioner.WebApi.Extensions;
using Questioner.WebApi.Mapper;
using Questioner.WebApi.Repositories;
using Questioner.WebApi.Services;
using Questioner.WebApi.Validators;
using System.Diagnostics.CodeAnalysis;

namespace Questioner.WebApi
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
            services.AddControllers();

            services.AddMvc().AddNewtonsoftJson(setup =>
            {
                setup.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                setup.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddFluentValidationAutoValidation();            
            services.AddValidatorsFromAssemblyContaining<ThemeModelValidator>();

            services.Configure<AppSettings>(options => Configuration.GetSection(nameof(AppSettings)).Bind(options));

            services.AddDbContext(Configuration);

            services.AddScoped<IThemeRepository, ThemeRepository>();            
            services.AddScoped<IThemeService, ThemeService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));            
            
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme).AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IContextService contextService,
            ILogger<Startup> logger,
            IOptions<AppSettings> options)
        {
            logger.LogInformation($"Environment: '{env.EnvironmentName}'.");
            logger.LogInformation($"Database connector: '{options.Value.DatabaseConnector}'.");

            var context = contextService.GetContext();
            logger.LogInformation($"Context database: '{context.Database.GetDbConnection().Database}'.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Database.Migrate();
        }
    }
}
