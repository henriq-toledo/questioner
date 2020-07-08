using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Interfaces;

namespace Questioner.Repository.Classes.Entities
{
    public class Context : DbContext, IContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Link> Links { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("<connection string>");
        }

        public static void SetupData()
        {
            using (var context = new Context())
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
}