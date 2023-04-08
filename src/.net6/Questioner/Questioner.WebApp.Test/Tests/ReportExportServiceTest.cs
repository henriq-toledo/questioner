using ClosedXML.Excel;
using NUnit.Framework;
using Questioner.WebApp.Models;
using Questioner.WebApp.Services;
using Questioner.WebApp.Test.Framework.Asserts;
using Questioner.WebApp.Test.Framework.Helpers;
using System.Collections.Generic;

namespace Questioner.WebApp.Test.Tests
{
    internal class ReportExportServiceTest
    {

        [Test]
        public void Export_WhenCalled_Exports()
        {
            // Arrange
            var expectedReportFileName = FileNameHelper.GetExpectedReportFileName();
            using var expectedReport = XLWorkbook.OpenFromTemplate(expectedReportFileName);

            var reportExportService = new ReportExportService();
            var resultViewModel = new ResultViewModel
            {
                ThemeName = "Theme name",
                ExamResult = Enums.ExamResult.Pass,
                Percentage = 80,
                Topics = new List<TopicResultViewModel>
                {
                    new TopicResultViewModel
                    {
                        Name = "Topic name",
                        Percentage = 100,
                        PercentageAnswered = 80
                    }
                },
                Questions = new List<QuestionResultViewModel>
                {
                    new QuestionResultViewModel
                    {
                        QuestionResult = Enums.QuestionResult.Correct,                        
                        QuestionText = "Question text"
                    }
                }
            };

            // Act
            using var reportStream = reportExportService.Export(resultViewModel);

            // Assert
            using var actualReport = new XLWorkbook(reportStream);

            ReportExportServiceAssert.AreEqual(expectedReport, actualReport);
        }
    }
}
