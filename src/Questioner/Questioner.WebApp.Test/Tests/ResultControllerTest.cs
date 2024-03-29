﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using Questioner.WebApp.Controllers;
using Questioner.WebApp.Models;
using Questioner.WebApp.Services;
using System.Text;

namespace Questioner.WebApp.Test.Tests
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
        public async Task Details_WhenCalled_ReturnsDetails()
        {
            // Arrange
            var themeViewModel = new ThemeViewModel { Id = 1 };
            var resultViewModel = new ResultViewModel();

            themeServiceMock.Setup(m => m.ExistsThemeById(themeViewModel.Id)).ReturnsAsync(true);

            resultServiceMock.Setup(m => m.Process(themeViewModel)).ReturnsAsync(resultViewModel);

            // Act
            var actionResult = await resultController.Details(themeViewModel);

            // Arrange
            Assert.That(actionResult, Is.InstanceOf<ViewResult>());

            var viewResult = actionResult as ViewResult;

            Assert.That(viewResult.Model, Is.SameAs(resultViewModel));

            themeServiceMock.Verify(m => m.ExistsThemeById(themeViewModel.Id), Times.Once);

            resultServiceMock.Verify(m => m.Process(themeViewModel), Times.Once);
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
            Assert.That(actionResult, Is.InstanceOf<NotFoundResult>());
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
            Assert.That(actionResult, Is.InstanceOf<FileContentResult>());

            var fileContentResult = actionResult as FileContentResult;

            Assert.Multiple(() =>
            {
                Assert.That(fileContentResult.FileDownloadName, Is.EqualTo(expectedFileDownloadName));
                Assert.That(fileContentResult.ContentType, Is.EqualTo(expectedContentType));
            });

            var fileContent = Encoding.UTF8.GetString(fileContentResult.FileContents);
            
            Assert.That(fileContent, Is.EqualTo(expectedFileContent));
        }
    }
}
