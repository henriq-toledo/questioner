using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Questioner.WebApi.Test.Framework.Asserts;
using Questioner.WebApi.Test.Framework.Defaults;
using Questioner.WebApi.Test.Framework.Extensions;
using Questioner.WebApi.Test.Framework.Factories;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.WebApi.Test.Tests.Controllers
{
    [TestFixture]
    public class ThemeControllerTest
    {
        [Test]
        public async Task ShouldGetThemes()
        {
            // Arrange
            using var context = ContextFactory.Create();
            var themeController = ThemeControllerFactory.Create(context);
            var expectedThemes = new [] { ThemeDefault.ThemeWithChildren };

            await context.InsertTheme(expectedThemes);

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
            using var context = ContextFactory.Create();
            var themeController = ThemeControllerFactory.Create(context);

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
            using var context = ContextFactory.Create();
            var themeController = ThemeControllerFactory.Create(context);

            await context.InsertTheme(ThemeDefault.ThemeWithChildren);

            var themeId = (await context.Themes.FirstOrDefaultAsync()).Id;

            // Act
            await themeController.Delete(themeId);

            // Assert
            Assert.False(context.Themes.Any(t => t.Id == themeId), 
                message: $"The theme id {themeId} should be deleted.");
        }
    }
}
