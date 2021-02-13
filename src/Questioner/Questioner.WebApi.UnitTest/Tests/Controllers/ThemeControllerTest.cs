using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Questioner.WebApi.Controllers;
using Questioner.WebApi.Repositories;
using Questioner.WebApi.Services;
using Questioner.WebApi.UnitTest.Framework.Asserts;
using Questioner.WebApi.UnitTest.Framework.Defaults;
using Questioner.WebApi.UnitTest.Framework.Factories;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.WebApi.UnitTest.Tests.Controllers
{
    [TestFixture]
    public class ThemeControllerTest
    {
        [Test]
        public async Task ShouldGetThemes()
        {
            // Arrange
            using var context = ContextFactory.CreateContext();
            var themeRepository = new ThemeRepository(context);
            var themeService = new ThemeService(themeRepository);
            var themeController = new ThemeController(themeService);
            var expectedThemes = new [] { ThemeDefault.ThemeWithChildren };

            context.Themes.AddRange(expectedThemes);
            await context.SaveChangesAsync();

            // Act
            var result = await themeController.Get(includeChildren: true);

            // Assert
            var actualThemes = result.Value;

            ThemeAssert.Assert(expectedThemes, actualThemes);
        }

        [Test]
        public async Task ShouldCreateTheme()
        {
            // Arrange
            using var context = ContextFactory.CreateContext();
            var themeRepository = new ThemeRepository(context);
            var themeService = new ThemeService(themeRepository);
            var themeController = new ThemeController(themeService);

            // Act
            await themeController.Create(ThemeModelDefault.ThemeWithChildren);

            // Assert
            var actualTheme = context.Themes.FirstOrDefault();

            ThemeAssert.Assert(expectedTheme: ThemeDefault.ThemeWithChildren, actualTheme);
        }

        [Test]
        public async Task ShouldDeleteTheme()
        {
            // Arrange
            using var context = ContextFactory.CreateContext();
            var themeRepository = new ThemeRepository(context);
            var themeService = new ThemeService(themeRepository);
            var themeController = new ThemeController(themeService);

            context.Themes.Add(ThemeDefault.ThemeWithChildren);
            await context.SaveChangesAsync();

            var themeId = (await context.Themes.FirstOrDefaultAsync()).Id;

            // Act
            await themeController.Delete(themeId);

            // Assert
            Assert.False(context.Themes.Any(t => t.Id == themeId), $"The theme id {themeId} should be deleted.");
        }
    }
}
