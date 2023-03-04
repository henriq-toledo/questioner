using Questioner.Repository.Classes.Entities;
using System.Linq;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.Test.Framework.Asserts
{
    public static class ThemeAssert
    {
        public static void Assert(Theme expectedTheme, Theme actualTheme)
            => Assert(new[] { expectedTheme }, new[] { actualTheme });

        public static void Assert(Theme[] expectedThemes, Theme[] actualThemes)
        {
            AreEqual(expectedThemes?.Length, actualThemes?.Length, 
                message: $"The expected number of themes should be {expectedThemes?.Length} and not {actualThemes?.Length}.");

            foreach (var expectedTheme in expectedThemes)
            {
                var actualTheme = actualThemes.FirstOrDefault(t => t.Name == expectedTheme.Name);

                NotNull(actualTheme, message: $"The theme '{expectedTheme.Name}' should exist.");

                AreEqual(expectedTheme.PassRate, actualTheme.PassRate,
                    message: $"For the theme '{expectedTheme.Name}', the {nameof(expectedTheme.PassRate)} should be {expectedTheme.PassRate} and not {actualTheme.PassRate}.");

                TopicAssert.Assert(expectedTopics: expectedTheme?.Topics, actualTopics: actualTheme?.Topics);
            }
        }
    }
}
