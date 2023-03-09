using Moq;
using NUnit.Framework;
using Questioner.Repository.Entities;
using Questioner.WebApi.Repositories;
using Questioner.WebApi.Services;
using System.Threading.Tasks;

namespace Questioner.WebApi.Test.Tests
{
    internal class ThemeServiceTest
    {
        private ThemeService themeService;
        private Mock<IThemeRepository> themeRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            themeRepositoryMock = new Mock<IThemeRepository>();

            themeService = new ThemeService(themeRepositoryMock.Object);
        }

        [Test]
        public async Task Create_WhenCalled_Creates()
        {
            // Arrange
            var theme = new Theme();

            // Act
            await themeService.Create(theme);

            // Assert
            themeRepositoryMock.Verify(m => m.Create(theme), Times.Once);
        }

        [Test]
        public async Task Delete_WhenCalled_Deletes()
        {
            // Arrange
            const int themeId = 1;

            // Act
            await themeService.Delete(themeId);

            // Assert
            themeRepositoryMock.Verify(m => m.Delete(themeId), Times.Once);
        }

        [Test]
        public async Task ExistsTheme_WhenExists_ReturnsTrue()
        {
            // Arrange
            const int themeId = 1;

            themeRepositoryMock.Setup(m => m.ExistsTheme(themeId)).ReturnsAsync(true);

            // Act
            var exists = await themeService.ExistsTheme(themeId);

            // Assert
            Assert.IsTrue(exists);

            themeRepositoryMock.Verify(m => m.ExistsTheme(themeId), Times.Once);
        }

        [Test]
        public async Task ExistsTheme_WhenNoExists_ReturnFalse()
        {
            // Arrange
            const int themeId = 1;

            themeRepositoryMock.Setup(m => m.ExistsTheme(themeId)).ReturnsAsync(false);

            // Act
            var exists = await themeService.ExistsTheme(themeId);

            // Assert
            Assert.IsFalse(exists);

            themeRepositoryMock.Verify(m => m.ExistsTheme(themeId), Times.Once);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAll_WhenCalled_ReturnsAllThemes(bool includeChildren)
        {
            // Arrange
            var themes = new Theme[] { };

            themeRepositoryMock.Setup(m => m.GetAll(includeChildren)).ReturnsAsync(themes);

            // Act
            var actualThemes = await themeService.GetAll(includeChildren);

            // Assert
            Assert.AreSame(themes, actualThemes);

            themeRepositoryMock.Verify(m => m.GetAll(includeChildren), Times.Once);
        }
    }
}
