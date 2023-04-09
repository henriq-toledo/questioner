using Questioner.Repository.Entities;

namespace Questioner.WebApi.Test.Framework.Defaults
{
    public static class ThemeDefault
    {
        public static Theme ThemeWithChildren =>
            new()
            {
                Name = "Test theme 1",
                PassRate = ThemePassRateDefault.Default,
                Topics = new List<Topic>()
                {
                    new()
                    {
                        Name = "Test topic 1",
                        Percentage = 100,
                        Questions = new List<Question>()
                        {
                            new()
                            {
                                QuestionText = "Test question 1",
                                Answers = new List<Answer>()
                                {
                                    new()
                                    {
                                        AnswerText = "Test answer true",
                                        IsCorrect = true
                                    },
                                    new()
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
            new()
            {
                Name = "Test theme 1"
            };

        public static Theme ThemeWithDefaultName => new() { Name = ThemeNameDefault.Default };
    }
}
