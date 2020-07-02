using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Interfaces;
using Questioner.Web.Enums;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class ResultController : BaseController
    {
        public ResultController(ILogger<ResultController> logger, IContext context)
            : base(logger, context)
        {
        }

        public ActionResult Details(ThemeViewModel theme)
        {
            var topics = context.Themes.AsQueryable().FirstOrDefault(t => t.Id == theme.Id).Topics;
            var questions = topics.Where(topic => topic.Questions != null).SelectMany(t => t.Questions).ToList();
            var model = new ResultViewModel();

            model.ThemeId = theme.Id;
            model.ThemeName = theme.Name;
            model.Topics = new List<TopicResultViewModel>();
            model.Questions = new List<QuestionResultViewModel>();

            foreach (var question in questions)
            {
                var answeredQuestion = theme.Questions.FirstOrDefault(q => q.Id == question.Id);
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
                    TopicId = question.Topic_Id,
                    QuestionText = question.QuestionText,
                    QuestionResult = questionResult
                });
            }

            foreach (var topic in topics)
            {
                var topicResult = new TopicResultViewModel(topic);
                var totalQuestionsPerTopic = model.Questions?.Count(q => q.TopicId == topic.Id);

                if (totalQuestionsPerTopic > 0)
                {
                    var answeredCorrectly = model.Questions.Where(q => q.TopicId == topic.Id).Count(q => q.QuestionResult == QuestionResultEnum.Correct);
                    var percentagePerTopic = (byte)(answeredCorrectly * 100 / totalQuestionsPerTopic);
                    var totalPerTopic = percentagePerTopic * topic.Percentage / 100;

                    topicResult.PercentageAnswered = (byte)totalPerTopic;
                }

                model.Topics.Add(topicResult);
            }

            model.Percentage = (byte)model.Topics.Sum(t => t.PercentageAnswered);

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
                worksheet.Cell(currentRow, 2).Value = $"{result.Percentage}%";

                currentRow++;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "#";
                worksheet.Cell(currentRow, 2).Value = "Topic";
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