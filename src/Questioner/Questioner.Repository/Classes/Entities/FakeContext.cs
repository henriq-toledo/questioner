using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Interfaces;

namespace Questioner.Repository.Classes.Entities
{
    public class FakeContext : IContext
    {
        public DbSet<Theme> Themes { get; set; } = new FakeDbSet<Theme>();
        public DbSet<Topic> Topics { get; set; } = new FakeDbSet<Topic>();
        public DbSet<Question> Questions { get; set; } = new FakeDbSet<Question>();
        public DbSet<Answer> Answers { get; set; } = new FakeDbSet<Answer>();
        public DbSet<Link> Links { get; set; } = new FakeDbSet<Link>();

        public FakeContext()
        {
            Themes.AddRange(new Theme()
            {
                Id = 1,
                Name = "Exam AZ-900: Microsoft Azure Fundamentals",
                Topics = new List<Topic>()
                {
                    new Topic()
                    {
                        Id = 1,
                        Name = "Describe cloud concepts",
                        Percentage = 20,
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Id = 1,
                                QuestionText = "Azure Web App is a PAAS service?",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Id = 1,
                                        AnswerText = "True",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        Id = 2,
                                        AnswerText = "False"
                                    }
                                }
                            },
                            new Question()
                            {
                                Id = 2,
                                QuestionText = "Azure Function is a IAAS service?",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Id = 3,
                                        AnswerText = "True",                                        
                                    },
                                    new Answer()
                                    {
                                        Id = 4,
                                        AnswerText = "False",
                                        IsCorrect = true
                                    }
                                }
                            },
                            new Question()
                            {
                                Id = 3,
                                QuestionText = "Azure IoT Central is a SAAS service?",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        Id = 5,
                                        AnswerText = "True",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        Id = 6,
                                        AnswerText = "False"
                                    }
                                }
                            }
                        }
                    },
                    new Topic()
                    {
                        Id = 2,
                        Name = "Describe core Azure services",
                        Percentage = 30
                    },
                    new Topic()
                    {
                        Id = 3,
                        Name = "Describe security, privacy, compliance, and trust",
                        Percentage = 25
                    },
                    new Topic()
                    {
                        Id = 4,
                        Name = "Describe Azure pricing Service Level Agreements, and Lifecycles",
                        Percentage = 25
                    }
                }
            },
            new Theme()
            {
                Id = 2,
                Name = "Exam AZ-204: Developing Solutions for Microsoft Azure",
                Topics = new List<Topic>()
                {
                    new Topic()
                    {
                        Id = 5,
                        Name = "Develop Azure compute solutions",
                        Percentage = 30
                    },
                    new Topic()
                    {
                        Id = 6,
                        Name = "Develop for Azure storage",
                        Percentage = 10
                    },
                    new Topic()
                    {
                        Id = 7,
                        Name = "Implement Azure security",
                        Percentage = 15
                    },
                    new Topic()
                    {
                        Id = 8,
                        Name = "Monitor, troubleshoot, and optimize Azure solutions",
                        Percentage = 15
                    },
                    new Topic()
                    {
                        Id = 9,
                        Name = "Connect to and consume Azure services and third-party services",
                        Percentage = 30
                    }
                }
            });

            foreach (var theme in Themes.AsQueryable())
            {
                foreach (var topic in theme.Topics)
                {
                    Topics.Add(topic);
                }
            }
        }
    }
}