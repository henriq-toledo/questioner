using AutoMapper;
using Moq;
using NUnit.Framework;
using Questioner.Repository.Entities;
using Questioner.Web.Mappers;
using Questioner.Web.Models;
using Questioner.Web.Services;
using Questioner.Web.Test.Framework.Asserts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
{
    internal class ResultServiceTest
    {
        private ResultService resultService;
        private Mock<IThemeService> themeServiceMock;

        [SetUp]
        public void SetUp()
        {            
            themeServiceMock = new Mock<IThemeService>();

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();

            resultService = new ResultService(themeServiceMock.Object, mapper);
        }

        [Test]
        public async Task Process_WhenCalled_Processes()
        {
            // Arrange
            var themeViewModel = new ThemeViewModel
            {
                Id = 1,
                Name = "Exam AZ-900: Microsoft Azure Fundamentals",
                Questions = new List<QuestionViewModel>
                {
                    new QuestionViewModel
                    {
                        Id = 11,                        
                        HowManyChoices = 1,
                        Answers = new List<AnswerViewModel>
                        {
                            new AnswerViewModel
                            {
                                Id = 101,                                
                                Selected = true
                            },
                            new AnswerViewModel
                            {
                                Id = 102                                
                            },
                            new AnswerViewModel
                            {
                                Id = 103
                            }
                        }
                    },
                    new QuestionViewModel
                    {
                        Id = 12,
                        QuestionText = "What are the four foundational principles of trust?",
                        HowManyChoices = 4,
                        Answers = new List<AnswerViewModel>
                        {
                            new AnswerViewModel
                            {
                                Id = 110,
                                Selected = true
                            },
                            new AnswerViewModel
                            {
                                Id = 111,
                                Selected = true
                            },
                            new AnswerViewModel
                            {
                                Id = 112,
                                Selected = true
                            },
                            new AnswerViewModel
                            {
                                Id = 113
                            },
                            new AnswerViewModel
                            {
                                Id = 114,
                                Selected = true
                            }
                        }
                    }
                }
            };

            themeServiceMock
                .Setup(m => m.GetThemeById(themeViewModel.Id))
                .ReturnsAsync(new Theme
                {
                    Id = 1,
                    Name = "Exam AZ-900: Microsoft Azure Fundamentals",
                    PassRate = 80,
                    Topics = new List<Topic>
                    {
                        new Topic
                        {
                            Id = 1001,
                            Name = "Describe cloud concepts",
                            Percentage = 50,
                            Questions = new List<Question>
                            {
                                new Question
                                {
                                    Id = 11,
                                    TopicId = 1001,
                                    QuestionText = "What is PAAS?",
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Id = 101,
                                            IsCorrect = true,
                                        },
                                        new Answer
                                        {
                                            Id = 102
                                        },
                                        new Answer
                                        {
                                            Id = 103
                                        }
                                    }
                                }
                            }
                        },
                        new Topic
                        {
                            Id = 1002,
                            Name = "What are the four foundational principles of trust?",
                            Percentage = 50,
                            Questions = new List<Question>
                            {
                                new Question
                                {
                                    Id = 12,
                                    QuestionText = "What are the four foundational principles of trust?",
                                    TopicId = 1002,
                                    Answers = new List<Answer>
                                    {
                                        new Answer
                                        {
                                            Id = 110,
                                            IsCorrect = true
                                        },
                                        new Answer
                                        {
                                            Id = 111,
                                            IsCorrect = true
                                        },
                                        new Answer
                                        {
                                            Id = 112,
                                            IsCorrect = true
                                        },
                                        new Answer
                                        {
                                            Id = 113                                        
                                        },
                                        new Answer
                                        {
                                            Id = 114,
                                            IsCorrect = true
                                        }
                                    }
                                }
                            }
                        }
                    }
                });

            var expectedResultViewModel = new ResultViewModel
            {
                ExamResult = Enums.ExamResult.Pass,
                Percentage = 100,
                ThemeName = "Exam AZ-900: Microsoft Azure Fundamentals",
                ThemeId = 1,
                Topics = new List<TopicResultViewModel> 
                {
                    new TopicResultViewModel
                    {
                        Id = 1001,
                        Name = "Describe cloud concepts",
                        Percentage = 50,
                        PercentageAnswered = 100
                    },
                    new TopicResultViewModel
                    {
                        Id = 1002,
                        Name = "What are the four foundational principles of trust?",
                        Percentage = 50,
                        PercentageAnswered = 100
                    }
                },
                Questions = new List<QuestionResultViewModel>
                {
                    new QuestionResultViewModel
                    {
                        Id = 11,
                        TopicId = 1001,
                        QuestionText = "What is PAAS?",
                        QuestionResult = Enums.QuestionResult.Correct
                    },
                    new QuestionResultViewModel
                    {
                        Id = 12,
                        TopicId = 1002,
                        QuestionText = "What are the four foundational principles of trust?",
                        QuestionResult = Enums.QuestionResult.Correct
                    }
                }

            };

            // Act
            var actualResultViewModel = await resultService.Process(themeViewModel);

            // Assert
            ObjectAssert.AreEqual(expectedResultViewModel, actualResultViewModel);
        }
    }
}
