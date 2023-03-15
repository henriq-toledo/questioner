using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using Questioner.Web.Repositories;
using Questioner.Web.Services;
using Questioner.Web.Test.Framework.Asserts;
using Questioner.Web.Test.Framework.Defaults;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
{
    internal class ThemeRepositoryTest
    {
        private AppSettings appSettings;
        private ThemeRepository themeRepository;
        private Mock<IOptions<AppSettings>> optionsMock;
        private Mock<ILogger<ThemeRepository>> loggerMock;
        private Mock<IHttpClientService> httpClientServiceMock;

        [SetUp]
        public void SetUp()
        {
            appSettings = new AppSettings();

            optionsMock = new Mock<IOptions<AppSettings>>();
            loggerMock = new Mock<ILogger<ThemeRepository>>();
            loggerMock = new Mock<ILogger<ThemeRepository>>();
            httpClientServiceMock = new Mock<IHttpClientService>();

            optionsMock.Setup(m => m.Value).Returns(appSettings);

            themeRepository = new ThemeRepository(optionsMock.Object, loggerMock.Object, httpClientServiceMock.Object);
        }

        [Test]
        public async Task GetAllThemes_WhenCalled_ReturnsAllThemes()
        {
            // Arrange
            const string questionerWebApiUrl = "https://questioner.com/";
            const string questionerWebApiThemeUrl = "https://questioner.com/theme?includeChildren=true";

            var expectedThemes = ThemeDefault.DefaultArray;

            appSettings.QuestionerWebApiUrl = questionerWebApiUrl;

            httpClientServiceMock.Setup(m => m.GetAsync(questionerWebApiThemeUrl)).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedThemes))
            });

            // Act
            var actualThemes = await themeRepository.GetAllThemes();

            // Assert
            ObjectAssert.AreCollectionsEqual(expectedThemes, actualThemes);
        }
    }
}
