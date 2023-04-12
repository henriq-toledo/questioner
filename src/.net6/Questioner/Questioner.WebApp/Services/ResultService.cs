using AutoMapper;
using Questioner.Repository.Entities;
using Questioner.WebApp.Enums;
using Questioner.WebApp.Models;

namespace Questioner.WebApp.Services
{
    public class ResultService : IResultService
    {
        private readonly IMapper mapper;
        private readonly IThemeService themeService;

        public ResultService(IThemeService themeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.themeService = themeService;
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

        private static List<QuestionResultViewModel> ProcessQuestions(Topic[] topics, List<QuestionViewModel> answeredQuestions)
        {
            var questionsResult = new List<QuestionResultViewModel>();

            foreach (var topic in topics)
            {
                foreach (var question in topic.Questions)
                {
                    var answeredQuestion = answeredQuestions.FirstOrDefault(q => q.Id == question.Id);
                    QuestionResult questionResult;

                    if (answeredQuestion is null || !answeredQuestion.Answers.Any(a => a.Selected))
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
                var topicResult = mapper.Map<TopicResultViewModel>(topic);
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
