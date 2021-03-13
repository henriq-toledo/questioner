using Questioner.Web.Models;
using System.Collections.Generic;
using System.Linq;
using static NUnit.Framework.Assert;

namespace Questioner.Web.UnitTest.Framework.Asserts
{
    public static class ThemeListViewModelAssert
    {
        public static void Assert(List<ThemeListViewModel> expectedThemeListViewModel, List<ThemeListViewModel> actualThemeListViewModel)
        {
            AreEqual(expectedThemeListViewModel?.Count, actualThemeListViewModel?.Count,
                message: $"The expected number of themes should be {expectedThemeListViewModel?.Count} and not {actualThemeListViewModel?.Count}.");

            foreach (var expectedTheme in expectedThemeListViewModel)
            {
                var actualTheme = actualThemeListViewModel.FirstOrDefault(t => t.Id == expectedTheme.Id);

                NotNull(actualTheme, message: $"The theme '{expectedTheme.Name}' should exist.");

                AreEqual(expectedTheme.Name, actualTheme.Name,
                    message: $"For the theme id '{expectedTheme.Id}', the {nameof(expectedTheme.Name)} should be {expectedTheme.Name} and not {actualTheme.Name}.");

                AreEqual(expectedTheme.PassRate, actualTheme.PassRate,
                    message: $"For the theme id '{expectedTheme.Id}', the {nameof(expectedTheme.PassRate)} should be {expectedTheme.PassRate} and not {actualTheme.PassRate}.");

                AreEqual(expectedTheme.TopicsQuantity, actualTheme.TopicsQuantity,
                    message: $"For the theme id '{expectedTheme.Id}', the {nameof(expectedTheme.TopicsQuantity)} should be {expectedTheme.TopicsQuantity} and not {actualTheme.TopicsQuantity}.");

                AreEqual(expectedTheme.QuestionsQuantity, actualTheme.QuestionsQuantity,
                    message: $"For the theme id '{expectedTheme.Id}', the {nameof(expectedTheme.QuestionsQuantity)} should be {expectedTheme.QuestionsQuantity} and not {actualTheme.QuestionsQuantity}.");
            }
        }
    }
}
