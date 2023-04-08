using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Questioner.Repository.Entities;
using Questioner.WebApp.Controllers;
using Questioner.WebApp.Models;
using Questioner.WebApp.Services;
using System.Threading.Tasks;

namespace Questioner.WebApp.Test.Tests
{
    internal class ThemeControllerTest
    {
        private Mock<IMapper> mapperMock;
        private ThemeController themeController;
        private Mock<IThemeService> themeServiceMock;

        [SetUp]
        public void SetUp()
        {
            mapperMock = new Mock<IMapper>();

            themeServiceMock = new Mock<IThemeService>();

            themeController = new ThemeController(themeServiceMock.Object, mapperMock.Object);
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
        public async Task Details_WhenCalled_ReturnsThemeDetailViewModel()
        {
            // Arrange
            const int themeId = 1;

            var theme = new Theme();
            var themeDetailViewModel = new ThemeDetailViewModel();

            themeServiceMock.Setup(m => m.GetThemeById(themeId)).ReturnsAsync(theme);
            mapperMock.Setup(m => m.Map<ThemeDetailViewModel>(theme)).Returns(themeDetailViewModel);

            // Act
            var actionResult = await themeController.Details(themeId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(actionResult);

            var actualThemeDetailViewModel = (actionResult as ViewResult).Model as ThemeDetailViewModel;

            themeServiceMock.Verify(m => m.GetThemeById(themeId), Times.Once);

            Assert.AreSame(themeDetailViewModel, actualThemeDetailViewModel);
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

        [Test]
        public async Task Exam_WhenCalled_ReturnsThemeViewModel()
        {
            // Arrange
            const int themeId = 1;

            var theme = new Theme();
            var themeViewModel = new ThemeViewModel();

            themeServiceMock.Setup(m => m.GetThemeById(themeId)).ReturnsAsync(theme);
            mapperMock.Setup(m => m.Map<ThemeViewModel>(theme)).Returns(themeViewModel);

            // Act
            var actionResult = await themeController.Exam(themeId);

            // Assert
            Assert.IsInstanceOf<ViewResult>(actionResult);

            var actualThemeViewModel = (actionResult as ViewResult).Model as ThemeViewModel;

            themeServiceMock.Verify(m => m.GetThemeById(themeId), Times.Once);

            Assert.AreSame(themeViewModel, actualThemeViewModel);
        }
    }
}
