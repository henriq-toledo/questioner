using Questioner.Repository.Entities;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.Test.Framework.Asserts
{
    public static class ThemeAssert
    {
        public static void Assert(Theme expectedTheme, Theme actualTheme)
            => Assert(new[] { expectedTheme }, new[] { actualTheme });

        public static void Assert(Theme[] expectedThemes, Theme[] actualThemes)
        {
            That(actualThemes?.Length, Is.EqualTo(expectedThemes?.Length), 
                message: $"The expected number of themes should be {expectedThemes?.Length} and not {actualThemes?.Length}.");

            foreach (var expectedTheme in expectedThemes)
            {
                var actualTheme = actualThemes.FirstOrDefault(t => t.Name == expectedTheme.Name);

                That(actualTheme, Is.Not.Null, message: $"The theme '{expectedTheme.Name}' should exist.");

                That(actualTheme.PassRate, Is.EqualTo(expectedTheme.PassRate),
                    message: $"For the theme '{expectedTheme.Name}', the {nameof(expectedTheme.PassRate)} should be {expectedTheme.PassRate} and not {actualTheme.PassRate}.");

                TopicAssert.Assert(expectedTopics: expectedTheme?.Topics, actualTopics: actualTheme?.Topics);
            }
        }
    }
}
