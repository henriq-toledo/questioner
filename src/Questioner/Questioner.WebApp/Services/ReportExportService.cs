using ClosedXML.Excel;
using Questioner.WebApp.Models;

namespace Questioner.WebApp.Services
{
    public class ReportExportService : IReportExportService
    {
        public MemoryStream Export(ResultViewModel resultViewModel)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Result");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Theme:";
            worksheet.Cell(currentRow, 2).Value = resultViewModel.ThemeName;

            currentRow++;

            worksheet.Cell(currentRow, 1).Value = "Result:";
            worksheet.Cell(currentRow, 2).Value = $"{resultViewModel.ExamResult}";

            currentRow++;

            worksheet.Cell(currentRow, 1).Value = "Percentage:";
            worksheet.Cell(currentRow, 2).Value = $"{resultViewModel.Percentage} %";

            currentRow++;
            currentRow++;

            worksheet.Cell(currentRow, 1).Value = "#";
            worksheet.Cell(currentRow, 2).Value = "Topic";
            worksheet.Cell(currentRow, 3).Value = "%";
            worksheet.Cell(currentRow, 4).Value = "Result";

            foreach (var topic in resultViewModel.Topics)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = resultViewModel.Topics.IndexOf(topic) + 1;
                worksheet.Cell(currentRow, 2).Value = topic.Name;
                worksheet.Cell(currentRow, 3).Value = topic.Percentage;
                worksheet.Cell(currentRow, 4).Value = $"{topic.PercentageAnswered} %";
            }

            currentRow++;
            currentRow++;

            worksheet.Cell(currentRow, 1).Value = "#";
            worksheet.Cell(currentRow, 2).Value = "Question";
            worksheet.Cell(currentRow, 3).Value = "Correct";

            foreach (var question in resultViewModel.Questions)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = resultViewModel.Questions.IndexOf(question) + 1;
                worksheet.Cell(currentRow, 2).Value = question.QuestionText;
                worksheet.Cell(currentRow, 3).Value = question.QuestionResultDescription;
            }

            var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream;
        }
    }
}
