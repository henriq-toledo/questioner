using Questioner.Repository.Classes.Entities;
using System.Linq;

namespace Questioner.WebApi.UnitTest.Framework.Asserts
{
    public static class ThemeAssert
    {
        public static void Assert(Theme expectedTheme, Theme actualTheme)
            => Assert(new[] { expectedTheme }, new[] { actualTheme });

        public static void Assert(Theme[] expectedThemes, Theme[] actualThemes)
        {
            NUnit.Framework.Assert.AreEqual(expectedThemes.Length, actualThemes.Length);

            foreach (var expectedTheme in expectedThemes)
            {
                var actualTheme = actualThemes.FirstOrDefault(t => t.Name == expectedTheme.Name);

                NUnit.Framework.Assert.NotNull(actualTheme);

                // Topics

                NUnit.Framework.Assert.AreEqual(expectedTheme?.Topics?.Count, actualTheme?.Topics?.Count);

                foreach (var expectedTopic in expectedTheme.Topics)
                {
                    var actualTopic = actualTheme.Topics.FirstOrDefault(t => t.Name == expectedTopic.Name);

                    NUnit.Framework.Assert.NotNull(actualTopic);

                    NUnit.Framework.Assert.AreEqual(expectedTopic.Percentage, actualTopic.Percentage);

                    // Questions

                    NUnit.Framework.Assert.AreEqual(expectedTopic?.Questions?.Count, actualTopic?.Questions?.Count);

                    foreach (var expectedQuestion in expectedTopic?.Questions)
                    {
                        var actualQuestion = actualTopic.Questions.FirstOrDefault(q => q.QuestionText == expectedQuestion.QuestionText);

                        NUnit.Framework.Assert.NotNull(actualQuestion);

                        // Answers

                        NUnit.Framework.Assert.AreEqual(expectedQuestion?.Answers?.Count, actualQuestion?.Answers?.Count);

                        foreach (var expectedAnswer in expectedQuestion?.Answers)
                        {
                            var actualAnswer = actualQuestion.Answers.FirstOrDefault(a => a.AnswerText == expectedAnswer.AnswerText);

                            NUnit.Framework.Assert.NotNull(actualAnswer);

                            NUnit.Framework.Assert.AreEqual(expectedAnswer.IsCorrect, actualAnswer.IsCorrect);
                        }
                    }
                }
            }
        }
    }
}
