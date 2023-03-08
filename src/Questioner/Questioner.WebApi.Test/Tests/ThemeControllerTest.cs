using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Questioner.Repository.Contexts;
using Questioner.WebApi.Controllers;
using Questioner.WebApi.Services;
using Questioner.WebApi.Test.Framework.Asserts;
using Questioner.WebApi.Test.Framework.Defaults;
using Questioner.WebApi.Test.Framework.Extensions;
using Questioner.WebApi.Test.Framework.Factories;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.WebApi.Test.Tests
{
    [TestFixture]
    public class ThemeControllerTest
    {
        private Context context;
        private ThemeController themeController;
        private Mock<IContextService> contextServiceMock;

        [SetUp]
        public void SetUp()
        {
            context = ContextFactory.Create();
            contextServiceMock = new Mock<IContextService>();
            contextServiceMock.Setup(m => m.GetContext()).Returns(context);

            themeController = ThemeControllerFactory.Create(contextServiceMock.Object);
        }

        [Test]
        public async Task ShouldGetThemes()
        {
            // Arrange
            var expectedThemes = new[] { ThemeDefault.ThemeWithChildren };

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
            // Act
            await themeController.Create(ThemeModelDefault.ThemeWithChildren);

            // Assert
            var actualTheme = context.Themes.FirstOrDefault();

            ThemeAssert.Assert(expectedTheme: ThemeDefault.ThemeWithChildren, actualTheme);
        }

        [Test]
        public async Task ShouldDeleteTheme()
        {
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
