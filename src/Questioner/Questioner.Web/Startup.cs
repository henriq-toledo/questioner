using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questioner.Repository.Classes.Entities;
using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Questioner.Web
{
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

            services.AddDbContext<Context>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")))
                .AddScoped<IContext, Context>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context context)
        {
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

            context.Database.Migrate();
            SetupData(context);
        }

        public static void SetupData(Context context)
        {
            if (context.Themes.Any() == false)
            {
                context.Themes.Add(new Theme()
                {
                    Name = "Exam AZ-900: Microsoft Azure Fundamentals",
                    Topics = new List<Topic>()
                    {
                        new Topic()
                        {
                            Name = "Describe cloud concepts",
                            Percentage = 20,
                            Questions = new List<Question>()
                            {
                                new Question()
                                {
                                    QuestionText = "Azure Web App is a PAAS service?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer()
                                        {
                                            AnswerText = "True",
                                            IsCorrect = true
                                        },
                                        new Answer()
                                        {
                                            AnswerText = "False"
                                        }
                                    }
                                },
                                new Question()
                                {
                                    QuestionText = "Azure Function is a IAAS service?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer()
                                        {
                                            AnswerText = "True",
                                        },
                                        new Answer()
                                        {
                                            AnswerText = "False",
                                            IsCorrect = true
                                        }
                                    }
                                },
                                new Question()
                                {
                                    QuestionText = "Azure IoT Central is a SAAS service?",
                                    Answers = new List<Answer>()
                                    {
                                        new Answer()
                                        {
                                            AnswerText = "True",
                                            IsCorrect = true
                                        },
                                        new Answer()
                                        {
                                            AnswerText = "False"
                                        }
                                    }
                                }
                            }
                        },
                        new Topic()
                        {
                            Name = "Describe core Azure services",
                            Percentage = 30
                        },
                        new Topic()
                        {
                            Name = "Describe security, privacy, compliance, and trust",
                            Percentage = 25
                        },
                        new Topic()
                        {
                            Name = "Describe Azure pricing Service Level Agreements, and Lifecycles",
                            Percentage = 25
                        }
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
