using Questioner.WebApp.Models;

namespace Questioner.WebApp.Test.Framework.Asserts
{
    internal static class ThemeListViewModelAssert
    {
        public static void AreEqual(List<ThemeListViewModel> expected, List<ThemeListViewModel> actual)
        {
            Assert.That(actual, Has.Count.EqualTo(expected.Count));

            for (int i = 0; i < expected.Count; i++)
            {
                var expectedThemeListViewModel = expected[i];
                var actualThemeListViewModel = actual[i];

                Assert.Multiple(() =>
                {
                    Assert.That(actualThemeListViewModel.Id, Is.EqualTo(expectedThemeListViewModel.Id));
                    Assert.That(actualThemeListViewModel.Name, Is.EqualTo(expectedThemeListViewModel.Name));
                    Assert.That(actualThemeListViewModel.PassRate, Is.EqualTo(expectedThemeListViewModel.PassRate));
                    Assert.That(actualThemeListViewModel.TopicsQuantity, Is.EqualTo(expectedThemeListViewModel.TopicsQuantity));
                    Assert.That(actualThemeListViewModel.QuestionsQuantity, Is.EqualTo(expectedThemeListViewModel.QuestionsQuantity));
                });
            }
        }
    }
}
