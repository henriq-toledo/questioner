using Questioner.WebApi.Models;

namespace Questioner.WebApi.Test.Framework.Defaults
{
    public static class ThemeModelDefault
    {
        public static ThemeModel ThemeWithChildren =>
            new()
            {
                Name = "Test theme 1",
                PassRate = ThemePassRateDefault.Default,
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

        public static ThemeModel ThemeWithQuestionWithOnlyOneAnswer => new()
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

        public static ThemeModel ThemeWithQuestionWithEmptyAnswers => new()
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

        public static ThemeModel ThemeWithQuestionWithNullAnswers => new()
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

        public static ThemeModel ThemeWithQuestionWithoutCorrectAnswer => new()
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

        public static ThemeModel ThemeWithTopicWithEmptyQuestions => new()
        {
            Topics = new List<TopicModel> { new TopicModel { Name = TopicNameDefault.Default, Questions = new List<QuestionModel>() } }
        };

        public static ThemeModel ThemeWithTopicWithNullQuestions => new()
        {
            Topics = new List<TopicModel> { new TopicModel { Name = TopicNameDefault.Default, Questions = null } }
        };

        public static ThemeModel ThemeWithTopicsPercentageMoreThanOneHundred => new()
        {
            Topics = new List<TopicModel>
            {
                new TopicModel { Percentage = 75 },
                new TopicModel { Percentage = 50 }
            }
        };

        public static ThemeModel ThemeWithTopicsPercentageLessThanOneHundred => new()
        {
            Topics = new List<TopicModel>
            {
                new TopicModel { Percentage = 25 },
                new TopicModel { Percentage = 50 }
            }
        };

        public static ThemeModel ThemeWithTopicsPercentageOneHundred => new()
        {
            Topics = new List<TopicModel>
            {
                new TopicModel { Percentage = 50 },
                new TopicModel { Percentage = 50 }
            }
        };

        public static ThemeModel ThemeWithNullTopics => new() { Topics = null };

        public static ThemeModel ThemeWithEmptyTopics => new() { Topics = new List<TopicModel>() };

        public static ThemeModel ThemeWithEmptyName => new() { Name = string.Empty };

        public static ThemeModel ThemeWithNullName => new() { Name = null };

        public static ThemeModel ThemeWithDefaultName => new() { Name = ThemeNameDefault.Default };

        public static ThemeModel ThemeWithPassRateLessThanMin => new() { Name = ThemeNameDefault.Default, PassRate = ThemePassRateDefault.LessThanMin };

        public static ThemeModel ThemeWithPassRateMoreThanMax => new() { Name = ThemeNameDefault.Default, PassRate = ThemePassRateDefault.MoreThanMax };

        public static ThemeModel ThemeWithMinValidPassRate => new() { Name = ThemeNameDefault.Default, PassRate = ThemePassRateDefault.MinValid };

        public static ThemeModel ThemeWithMaxValidPassRate => new() { Name = ThemeNameDefault.Default, PassRate = ThemePassRateDefault.MaxValid };
    }
}
