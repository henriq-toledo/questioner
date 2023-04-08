using Questioner.Repository.Entities;
using System.Collections.Generic;

namespace Questioner.WebApp.Test.Framework.Defaults
{
    internal static class ThemeDefault
    {
        public static Theme[] DefaultArray => new Theme[]
        {
            new Theme
            {
                Id = 1,
                Name = "Test theme",
                PassRate = 80,
                Topics = new List<Topic>
                {
                    new Topic
                    {
                        Id = 2,
                        Name = "Test topic",
                        Percentage = 100,
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Id = 3,
                                QuestionText = "Test question",
                                Answers = new List<Answer>
                                {
                                    new Answer
                                    {
                                        Id = 5,
                                        AnswerText = "Test answer 1",
                                        IsCorrect = true,
                                    },
                                    new Answer
                                    {
                                        Id = 6,
                                        AnswerText = "Test answer 2",
                                        IsCorrect = false,
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
    }
}
