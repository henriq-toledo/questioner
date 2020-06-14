using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly ILogger<ResultController> _logger;

        public ResultController(ILogger<ResultController> logger)
        {
            _logger = logger;
        }

        public ActionResult Details()
        {
            return View(new ResultViewModel()
            {
                ThemeId = 1,
                ThemeName = "Exam AZ-900",
                Percentage = 20,
                Topics = new List<TopicResultViewModel>()
                {
                    new TopicResultViewModel()
                    {
                        Id = 1,
                        Name = "Topic 1",
                        Percentage = 15,
                        PercentageAnswered = 10
                    },
                    new TopicResultViewModel()
                    {
                        Id = 2,
                        Name = "Topic 2",
                        Percentage = 15,
                        PercentageAnswered = 10
                    },
                    new TopicResultViewModel()
                    {
                        Id = 3,
                        Name = "Topic 3",
                        Percentage = 20,
                        PercentageAnswered = 15
                    },
                    new TopicResultViewModel()
                    {
                        Id = 4,
                        Name = "Topic 4",
                        Percentage = 35,
                        PercentageAnswered = 30
                    }
                },
                Questions = new List<QuestionResultViewModel>()
                {
                    new QuestionResultViewModel()
                    {
                        Id = 1,
                        QuestionText = "Quesion 1",
                        IsCorrect = true
                    },
                    new QuestionResultViewModel()
                    {
                        Id = 2,
                        QuestionText = "Question 2",
                        IsCorrect = false
                    }
                }
            });
        }

        [HttpPost]
        public ActionResult Export(ResultViewModel result)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Result");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "Theme:";
                worksheet.Cell(currentRow, 2).Value = result.ThemeName;

                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Percentage:";
                worksheet.Cell(currentRow, 2).Value = $"{result.Percentage}%";

                currentRow++;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "#";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "%";
                worksheet.Cell(currentRow, 4).Value = "Answered";

                foreach (var topic in result.Topics)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = result.Topics.IndexOf(topic) + 1;
                    worksheet.Cell(currentRow, 2).Value = topic.Name;
                    worksheet.Cell(currentRow, 3).Value = topic.Percentage;
                    worksheet.Cell(currentRow, 4).Value = topic.PercentageAnswered;
                }

                currentRow++;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "#";
                worksheet.Cell(currentRow, 2).Value = "Question";
                worksheet.Cell(currentRow, 3).Value = "Correct";
                
                foreach (var question in result.Questions)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = result.Questions.IndexOf(question) + 1;
                    worksheet.Cell(currentRow, 2).Value = question.QuestionText;
                    worksheet.Cell(currentRow, 3).Value = question.IsCorrect;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "result.xlsx");
                }
            }
        }
    }
}