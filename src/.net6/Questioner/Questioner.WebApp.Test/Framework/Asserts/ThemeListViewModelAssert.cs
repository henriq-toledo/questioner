using NUnit.Framework;
using Questioner.WebApp.Models;
using System.Collections.Generic;

namespace Questioner.WebApp.Test.Framework.Asserts
{
    internal static class ThemeListViewModelAssert
    {
        public static void AreEqual(List<ThemeListViewModel> expected, List<ThemeListViewModel> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                var expectedThemeListViewModel = expected[i];
                var actualThemeListViewModel = actual[i];

                Assert.AreEqual(expectedThemeListViewModel.Id, actualThemeListViewModel.Id);
                Assert.AreEqual(expectedThemeListViewModel.Name, actualThemeListViewModel.Name);
                Assert.AreEqual(expectedThemeListViewModel.PassRate, actualThemeListViewModel.PassRate);
                Assert.AreEqual(expectedThemeListViewModel.TopicsQuantity, actualThemeListViewModel.TopicsQuantity);
                Assert.AreEqual(expectedThemeListViewModel.QuestionsQuantity, actualThemeListViewModel.QuestionsQuantity);
            }
        }
    }
}
