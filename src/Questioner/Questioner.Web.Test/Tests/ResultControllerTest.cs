using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Questioner.Web.Controllers;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
{
    internal class ResultControllerTest
    {
        private ResultController resultController;
        private Mock<IThemeService> themeServiceMock;
        private Mock<IResultService> resultServiceMock;
        private Mock<IReportExportService> reportExportServiceMock;

        [SetUp]
        public void SetUp()
        {
            themeServiceMock = new Mock<IThemeService>();
            resultServiceMock = new Mock<IResultService>();
            reportExportServiceMock = new Mock<IReportExportService>();

            resultController = new ResultController(themeServiceMock.Object, resultServiceMock.Object, reportExportServiceMock.Object);
        }

        [Test]
        public async Task Details_WithInexistentThemeId_ReturnsNotFound()
        {
            // Arrange
            var themeViewModel = new ThemeViewModel { Id = 1 };
            themeServiceMock.Setup(m => m.ExistsThemeById(themeViewModel.Id)).ReturnsAsync(false);

            // Act
            var actionResult = await resultController.Details(themeViewModel);

            // Arrange
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }
    }
}
