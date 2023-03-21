using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Questioner.Web.Controllers;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.IO;
using System.Text;
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
            themeServiceMock.Verify(m => m.ExistsThemeById(themeViewModel.Id), Times.Once);
        }

        [Test]
        public void Export_WhenCalled_Exports()
        {
            // Arrange
            const string expectedFileContent = "Test";
            const string expectedFileDownloadName = "result.xlsx";
            const string expectedContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var resultViewModel = new ResultViewModel();

            using var memoryStream = new MemoryStream();
            using var streamWriter = new StreamWriter(memoryStream);

            streamWriter.Write(expectedFileContent);
            streamWriter.Flush();

            reportExportServiceMock.Setup(m => m.Export(resultViewModel)).Returns(memoryStream);

            // Act
            var actionResult = resultController.Export(resultViewModel);

            // Assert
            Assert.IsInstanceOf<FileContentResult>(actionResult);

            var fileContentResult = actionResult as FileContentResult;

            Assert.AreEqual(expectedFileDownloadName, fileContentResult.FileDownloadName);
            Assert.AreEqual(expectedContentType, fileContentResult.ContentType);

            var fileContent = Encoding.UTF8.GetString(fileContentResult.FileContents);
            
            Assert.AreEqual(expectedFileContent, fileContent);
        }
    }
}
