using ClosedXML.Excel;
using Questioner.Repository.Classes.Entities;
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

        public async Task<ResultViewModel> Process(ThemeViewModel themeViewModel)
        {
            var theme = await themeService.GetThemeById(themeViewModel.Id);
            var topics = theme.Topics.ToArray();
            var questionsResult = ProcessQuestions(topics, answeredQuestions: themeViewModel.Questions);
            var model = new ResultViewModel
            {
                ThemeId = themeViewModel.Id,
                ThemeName = themeViewModel.Name,
                Topics = ProcessTopics(topics, questionsResult),
                Questions = questionsResult
            };

            model.Percentage = (byte)model.Topics.Sum(topic => topic.PercentageAnswered * topic.Percentage / 100);
            model.ExamResult = model.Percentage >= theme.PassRate ? ExamResult.Pass : ExamResult.Fail;

            return model;
        }

        private List<QuestionResultViewModel> ProcessQuestions(Topic[] topics, List<QuestionViewModel> answeredQuestions)
        {
            var questionsResult = new List<QuestionResultViewModel>();

            foreach (var topic in topics)
            {
                foreach (var question in topic.Questions)
                {
                    var answeredQuestion = answeredQuestions.FirstOrDefault(q => q.Id == question.Id);
                    QuestionResult questionResult;

                    if (answeredQuestion.Answers.All(a => !a.Selected))
                    {
                        questionResult = QuestionResult.NotAnswered;
                    }
                    else
                    {
                        var correct = answeredQuestion.Answers
                            .All(answer => question.Answers.Any(a => a.Id == answer.Id && a.IsCorrect == answer.Selected));

                        questionResult = correct ? QuestionResult.Correct : QuestionResult.Incorrect;
                    }

                    questionsResult.Add(new QuestionResultViewModel()
                    {
                        Id = question.Id,
                        TopicId = topic.Id,
                        QuestionText = question.QuestionText,
                        QuestionResult = questionResult
                    });
                }
            }

            return questionsResult;
        }

        private List<TopicResultViewModel> ProcessTopics(Topic[] topics, List<QuestionResultViewModel> questionsResult)
        {
            var topicsResult = new List<TopicResultViewModel>();

            foreach (var topic in topics)
            {
                var topicResult = new TopicResultViewModel(topic);
                var totalQuestionsPerTopic = questionsResult.Count(q => q.TopicId == topic.Id);

                if (totalQuestionsPerTopic > 0)
                {
                    var answeredCorrectly = questionsResult.Where(q => q.TopicId == topic.Id).Count(q => q.QuestionResult == QuestionResult.Correct);
                    var percentagePerTopic = (byte)(answeredCorrectly * 100 / totalQuestionsPerTopic);

                    topicResult.PercentageAnswered = percentagePerTopic;
                }

                topicsResult.Add(topicResult);
            }

            return topicsResult;
        }
    }
}
