using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Questioner.Web.Enums;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly IThemeService themeService;

        public ResultController(IThemeService themeService)
        {
            this.themeService = themeService;
        }

        public async Task<ActionResult> Details(ThemeViewModel themeViewModel)
        {
            var theme = await themeService.GetThemeById(themeViewModel.Id);

            if (theme == null)
            {
                return NotFound();
            }

            var topics = theme.Topics.ToArray();

            var model = new ResultViewModel();

            model.ThemeId = themeViewModel.Id;
            model.ThemeName = themeViewModel.Name;
            model.Topics = new List<TopicResultViewModel>();
            model.Questions = new List<QuestionResultViewModel>();

            foreach (var topic in topics)
            {
                foreach (var question in topic.Questions)
                {
                    var answeredQuestion = themeViewModel.Questions.FirstOrDefault(q => q.Id == question.Id);
                    QuestionResultEnum questionResult;

                    if (answeredQuestion.Answers.All(a => a.Selected == false))
                    {
                        questionResult = QuestionResultEnum.NotAnswered;
                    }
                    else
                    {
                        var correct = answeredQuestion.Answers
                            .All(answer => question.Answers.Any(a => a.Id == answer.Id && a.IsCorrect == answer.Selected));

                        questionResult = correct ? QuestionResultEnum.Correct : QuestionResultEnum.Incorrect;
                    }

                    model.Questions.Add(new QuestionResultViewModel()
                    {
                        Id = question.Id,
                        TopicId = topic.Id,
                        QuestionText = question.QuestionText,
                        QuestionResult = questionResult
                    });
                }
            }

            foreach (var topic in topics)
            {
                var topicResult = new TopicResultViewModel(topic);
                var totalQuestionsPerTopic = model.Questions.Count(q => q.TopicId == topic.Id);

                if (totalQuestionsPerTopic > 0)
                {
                    var answeredCorrectly = model.Questions.Where(q => q.TopicId == topic.Id).Count(q => q.QuestionResult == QuestionResultEnum.Correct);
                    var percentagePerTopic = (byte)(answeredCorrectly * 100 / totalQuestionsPerTopic);

                    topicResult.PercentageAnswered = percentagePerTopic;
                }

                model.Topics.Add(topicResult);
            }

            model.Percentage = (byte)model.Topics.Sum(topic => topic.PercentageAnswered * topic.Percentage / 100);

            return View(model);
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
                worksheet.Cell(currentRow, 2).Value = $"{result.Percentage} %";

                currentRow++;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "#";
                worksheet.Cell(currentRow, 2).Value = "Topic";
                worksheet.Cell(currentRow, 3).Value = "%";
                worksheet.Cell(currentRow, 4).Value = "Result";

                foreach (var topic in result.Topics)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = result.Topics.IndexOf(topic) + 1;
                    worksheet.Cell(currentRow, 2).Value = topic.Name;
                    worksheet.Cell(currentRow, 3).Value = topic.Percentage;
                    worksheet.Cell(currentRow, 4).Value = $"{topic.PercentageAnswered} %";
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
                    worksheet.Cell(currentRow, 3).Value = question.QuestionResultDescription;
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