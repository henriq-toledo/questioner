using Questioner.WebApi.Models;
using System.Collections.Generic;

namespace Questioner.WebApi.UnitTest.Framework.Defaults
{
    public static class ThemeModelDefault
    {
        public static ThemeModel ThemeWithChildren =>
            new ThemeModel()
            {
                Name = "Test theme 1",
                Topics = new List<TopicModel>()
                {
                    new TopicModel()
                    {
                        Name = "Test topic 1",
                        Percentage = 100,
                        Questions = new List<QuestionModel>()
                        {
                            new QuestionModel()
                            {
                                QuestionText = "Test question 1",
                                Answers = new List<AnswerModel>()
                                {
                                    new AnswerModel()
                                    {
                                        AnswerText = "Test answer true",
                                        IsCorrect = true
                                    },
                                    new AnswerModel()
                                    {
                                        AnswerText = "Test answer false"
                                    }
                                }
                            }
                        }
                    }
                }
            };

        public static ThemeModel ThemeWithQuestionWithOnlyOneAnswer => new ThemeModel
        {
            Topics = new List<TopicModel>
                {
                    new TopicModel
                    {
                        Questions = new List<QuestionModel>
                        {
                            new QuestionModel
                            {
                                QuestionText = QuestionTextDefault.Default,
                                Answers = new List<AnswerModel>
                                {
                                    new AnswerModel()
                                }
                            }
                        }
                    }
                }
        };

        public static ThemeModel ThemeWithQuestionWithEmptyAnswers => new ThemeModel
        {
            Topics = new List<TopicModel>
                {
                    new TopicModel
                    {
                        Questions = new List<QuestionModel>
                        {
                            new QuestionModel
                            {
                                QuestionText = QuestionTextDefault.Default,
                                Answers = new List<AnswerModel>()
                            }
                        }
                    }
                }
        };

        public static ThemeModel ThemeWithQuestionWithNullAnswers => new ThemeModel
        {
            Topics = new List<TopicModel>
                {
                    new TopicModel
                    {
                        Questions = new List<QuestionModel>
                        {
                            new QuestionModel
                            {
                                QuestionText = QuestionTextDefault.Default,
                                Answers = null
                            }
                        }
                    }
                }
        };

        public static ThemeModel ThemeWithQuestionWithoutCorrectAnswer => new ThemeModel
        {
            Topics = new List<TopicModel>
                {
                    new TopicModel
                    {
                        Questions = new List<QuestionModel>
                        {
                            new QuestionModel
                            {
                                QuestionText = QuestionTextDefault.Default,
                                Answers = new List<AnswerModel>
                                {
                                    new AnswerModel
                                    {
                                        IsCorrect = false
                                    },
                                    new AnswerModel
                                    {
                                        IsCorrect = false
                                    }
                                }
                            }
                        }
                    }
                }
        };

        public static ThemeModel ThemeWithTopicWithEmptyQuestions => new ThemeModel
        {
            Topics = new List<TopicModel> { new TopicModel { Name = TopicNameDefault.Default, Questions = new List<QuestionModel>() } }
        };

        public static ThemeModel ThemeWithTopicWithNullQuestions => new ThemeModel
        {
            Topics = new List<TopicModel> { new TopicModel { Name = TopicNameDefault.Default, Questions = null } }
        };

        public static ThemeModel ThemeWithTopicsPercentageMoreThanOneHundred => new ThemeModel
        {
            Topics = new List<TopicModel>
            {
                new TopicModel { Percentage = 75 },
                new TopicModel { Percentage = 50 }
            }
        };

        public static ThemeModel ThemeWithTopicsPercentageLessThanOneHundred = new ThemeModel
        {
            Topics = new List<TopicModel>
            {
                new TopicModel { Percentage = 25 },
                new TopicModel { Percentage = 50 }
            }
        };

        public static ThemeModel ThemeWithTopicsPercentageOneHundred => new ThemeModel
        {
            Topics = new List<TopicModel>
            {
                new TopicModel { Percentage = 50 },
                new TopicModel { Percentage = 50 }
            }
        };

        public static ThemeModel ThemeWithNullTopics => new ThemeModel { Topics = null };

        public static ThemeModel ThemeWithEmptyTopics => new ThemeModel { Topics = new List<TopicModel>() };

        public static ThemeModel ThemeWithEmptyName => new ThemeModel { Name = string.Empty };

        public static ThemeModel ThemeWithNullName => new ThemeModel { Name = null };
    }
}
