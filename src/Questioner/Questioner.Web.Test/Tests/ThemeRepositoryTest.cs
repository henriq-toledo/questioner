using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Questioner.Repository.Entities;
using Questioner.Web.Repositories;
using Questioner.Web.Services;
using Questioner.Web.Test.Framework.Asserts;
using Questioner.Web.Test.Framework.Defaults;
using Questioner.Web.Test.Framework.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
{
    internal class ThemeRepositoryTest
    {
        private AppSettings appSettings;
        private ThemeRepository themeRepository;
        private HttpResponseMessage httpResponseMessage;
        private Mock<IOptions<AppSettings>> optionsMock;
        private Mock<ILogger<ThemeRepository>> loggerMock;
        private Mock<IHttpClientService> httpClientServiceMock;

        [SetUp]
        public void SetUp()
        {
            const string questionerWebApiUrl = "https://questioner.com/";
            const string questionerWebApiThemeUrl = "https://questioner.com/theme?includeChildren=true";

            appSettings = new AppSettings { QuestionerWebApiUrl = questionerWebApiUrl };

            optionsMock = new Mock<IOptions<AppSettings>>();
            loggerMock = new Mock<ILogger<ThemeRepository>>();
            loggerMock = new Mock<ILogger<ThemeRepository>>();
            httpClientServiceMock = new Mock<IHttpClientService>();

            optionsMock.Setup(m => m.Value).Returns(appSettings);

            themeRepository = new ThemeRepository(optionsMock.Object, loggerMock.Object, httpClientServiceMock.Object);

            httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            httpClientServiceMock.Setup(m => m.GetAsync(questionerWebApiThemeUrl)).ReturnsAsync(httpResponseMessage);
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

            httpClientServiceMock.Setup(m => m.GetAsync(It.IsAny<string>())).Throws(new Exception());

            // Act
            var actualThemes = await themeRepository.GetAllThemes();

            // Assert
            ObjectAssert.AreEqual(expectedThemes, actualThemes);

            httpClientServiceMock.Verify(m => m.GetAsync(It.IsAny<string>()), Times.Once);
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
