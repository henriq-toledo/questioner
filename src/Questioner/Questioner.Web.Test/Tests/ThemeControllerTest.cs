using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Questioner.Web.Controllers;
using Questioner.Web.Services;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
{
    internal class ThemeControllerTest
    {
        private ThemeController themeController;
        private Mock<IThemeService> themeServiceMock;

        [SetUp]
        public void SetUp()
        {
            themeServiceMock = new Mock<IThemeService>();

            themeController = new ThemeController(themeServiceMock.Object);
        }

        [Test]
        public async Task Details_WithInexistentThemeId_ReturnsNotFound()
        {
            // Arrange
            const int themeId = 1;

            // Act
            var actionResult = await themeController.Details(themeId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
            themeServiceMock.Verify(m => m.GetThemeById(themeId), Times.Once);
        }

        [Test]
        public async Task Exam_WithInexistentThemeId_ReturnsNotFound()
        {
            // Arrange
            const int themeId = 1;

            // Act
            var actionResult = await themeController.Exam(themeId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
            themeServiceMock.Verify(m => m.GetThemeById(themeId), Times.Once);
        }
    }
}
