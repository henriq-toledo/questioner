using Questioner.Repository.Classes.Entities;
using System.Collections.Generic;

namespace Questioner.WebApi.Test.Framework.Defaults
{
    public static class ThemeDefault
    {
        public static Theme ThemeWithChildren =>
            new Theme()
            {
                Name = "Test theme 1",
                PassRate = ThemePassRateDefault.Default,
                Topics = new List<Topic>()
                {
                    new Topic()
                    {
                        Name = "Test topic 1",
                        Percentage = 100,
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                QuestionText = "Test question 1",
                                Answers = new List<Answer>()
                                {
                                    new Answer()
                                    {
                                        AnswerText = "Test answer true",
                                        IsCorrect = true
                                    },
                                    new Answer()
                                    {
                                        AnswerText = "Test answer false"
                                    }
                                }
                            }
                        }
                    }
                }
            };

        public static Theme ThemeWithoutChildren =>
            new Theme()
            {
                Name = "Test theme 1"
            };

        public static Theme ThemeWithDefaultName => new Theme { Name = ThemeNameDefault.Default };
    }
}
