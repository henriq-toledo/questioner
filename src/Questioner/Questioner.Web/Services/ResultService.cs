using ClosedXML.Excel;
using Questioner.Web.Enums;
using Questioner.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public class ResultService : IResultService
    {
        private readonly IThemeService themeService;

        public ResultService(IThemeService themeService)
        {
            this.themeService = themeService;
        }

        public MemoryStream Export(ResultViewModel resultViewModel)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Result");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Theme:";
            worksheet.Cell(currentRow, 2).Value = resultViewModel.ThemeName;

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

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return stream;
        }

        public async Task<ResultViewModel> Process(ThemeViewModel themeViewModel)
        {
            var theme = await themeService.GetThemeById(themeViewModel.Id);
            var topics = theme.Topics.ToArray();
            var model = new ResultViewModel
            {
                ThemeId = themeViewModel.Id,
                ThemeName = themeViewModel.Name,
                Topics = new List<TopicResultViewModel>(),
                Questions = new List<QuestionResultViewModel>()
            };

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

            return model;
        }
    }
}
