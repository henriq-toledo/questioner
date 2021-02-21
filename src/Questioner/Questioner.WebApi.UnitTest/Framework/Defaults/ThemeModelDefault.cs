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

        public static ThemeModel ThemeWithQuestionWithNullAnswers = new ThemeModel
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
    }
}
