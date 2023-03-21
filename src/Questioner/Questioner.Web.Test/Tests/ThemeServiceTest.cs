﻿using Moq;
using NUnit.Framework;
using Questioner.Repository.Entities;
using Questioner.Web.Repositories;
using Questioner.Web.Services;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
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
        public async Task ExistsThemeById_WhenThemeIdExists_ReturnsTrue()
        {
            // Arrange
            const int themeId = 1;

            themeRepositoryMock.Setup(m => m.ExistsThemeById(themeId)).ReturnsAsync(true);

            // Act
            var exist = await themeService.ExistsThemeById(themeId);

            // Assert
            Assert.IsTrue(exist);
        }

        [Test]
        public async Task ExistsThemeById_WhenThemeIdNotExists_ReturnsFalse()
        {
            // Arrange
            const int themeId = 1;

            themeRepositoryMock.Setup(m => m.ExistsThemeById(themeId)).ReturnsAsync(false);

            // Act
            var exist = await themeService.ExistsThemeById(themeId);

            // Assert
            Assert.IsFalse(exist);
        }

        [Test]
        public async Task GetAllThemes_WhenCalled_ReturnsAllThemes()
        {
            // Arrange
            var expectedThemes = new Theme[] { };

            themeRepositoryMock.Setup(m => m.GetAllThemes()).ReturnsAsync(expectedThemes);

            // Act
            var actualThemes = await themeService.GetAllThemes();

            // Assert
            Assert.AreSame(expectedThemes, actualThemes);

        }

        [Test]
        public async Task GetThemeById_WhenCalled_ReturnsTheme()
        {
            // Arrange
            const int themeId = 1;

            var expectedTheme = new Theme();

            themeRepositoryMock.Setup(m => m.GetThemeById(themeId)).ReturnsAsync(expectedTheme);

            // Act
            var actualTheme = await themeService.GetThemeById(themeId);

            // Assert
            Assert.AreSame(expectedTheme, actualTheme);
        }
    }
}