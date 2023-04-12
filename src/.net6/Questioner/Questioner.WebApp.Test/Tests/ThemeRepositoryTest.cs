using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using Questioner.Repository.Entities;
using Questioner.WebApp.Repositories;
using Questioner.WebApp.Services;
using Questioner.WebApp.Test.Framework.Asserts;
using Questioner.WebApp.Test.Framework.Defaults;
using Questioner.WebApp.Test.Framework.Extensions;
using System.Net;

namespace Questioner.WebApp.Test.Tests
{
    internal class ThemeRepositoryTest
    {
        private ThemeRepository themeRepository;
        private HttpResponseMessage httpResponseMessage;
        private Mock<ILogger<ThemeRepository>> loggerMock;
        private Mock<IQuestionerWebApiService> questionerWebApiServiceMock;

        [SetUp]
        public void SetUp()
        {
            loggerMock = new Mock<ILogger<ThemeRepository>>();
            loggerMock = new Mock<ILogger<ThemeRepository>>();
            questionerWebApiServiceMock = new Mock<IQuestionerWebApiService>();

            themeRepository = new ThemeRepository(loggerMock.Object, questionerWebApiServiceMock.Object);

            httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            questionerWebApiServiceMock.Setup(m => m.GetAsync()).ReturnsAsync(httpResponseMessage);
        }

        [Test]
        public async Task GetAllThemes_WhenCalled_ReturnsAllThemes()
        {
            // Arrange
            var expectedThemes = ThemeDefault.DefaultArray;

            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(expectedThemes));

            // Act
            var actualThemes = await themeRepository.GetAllThemes();

            // Assert
            ObjectAssert.AreCollectionsEqual(expectedThemes, actualThemes);
        }



        [Test]
        public async Task GetAllThemes_WhenExceptionOccurs_ReturnsAllThemes()
        {
            // Arrange
            var expectedThemes = ThemeDefault.DefaultArray;

            themeRepository.SetThemes(expectedThemes);

            questionerWebApiServiceMock.Setup(m => m.GetAsync()).Throws(new Exception());

            // Act
            var actualThemes = await themeRepository.GetAllThemes();

            // Assert
            ObjectAssert.AreEqual(expectedThemes, actualThemes);

            questionerWebApiServiceMock.Verify(m => m.GetAsync(), Times.Once);
        }

        [Test]
        public async Task ExistsThemeById_WhenExists_RetrunsTrue()
        {
            // Arrange
            const int themeId = 1;

            var expectedThemes = new Theme[] { new Theme { Id = themeId } };

            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(expectedThemes));

            // Act
            var exists = await themeRepository.ExistsThemeById(themeId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsThemeById_WhenNoExists_ReturnsFalse()
        {
            // Arrange
            const int themeId = 1;            

            var expectedThemes = new Theme[] { new Theme { } };

            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(expectedThemes));

            // Act
            var exists = await themeRepository.ExistsThemeById(themeId);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetThemeById_WhenCalled_Returns()
        {
            // Arrange
            const int themeId = 1;

            var expectedTheme = new Theme { Id = themeId };
            var expectedThemes = new Theme[] { expectedTheme };

            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(expectedThemes));

            // Act
            var actualTheme = await themeRepository.GetThemeById(themeId);

            // Assert
            ObjectAssert.AreEqual(expectedTheme, actualTheme);
        }
    }
}
