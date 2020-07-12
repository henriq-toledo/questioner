using Questioner.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questioner.WebApi.Validators
{
    public class ThemeValidator
    {
        private ThemeModel _themeModel;

        public ThemeValidator(ThemeModel themeModel)
        {
            _themeModel = themeModel;
        }

        public string Validate()
        {
            var errors = new StringBuilder();

            if (_themeModel.Topics == null ||_themeModel.Topics.Count == 0)
            {
                errors.AppendLine("The theme must have at least one topic.");
            }
            else
            {
                var totalTopicsPercentage = _themeModel.Topics.Sum(topic => topic.Percentage);

                if (totalTopicsPercentage != 100)
                {
                    errors.AppendLine("The sum of the all topics percentage must be 100.");
                }

                foreach (var topicWithoutQuestions in _themeModel.Topics.Where(topic => topic.Questions?.Count == 0))
                {
                    errors.AppendLine($"The '{topicWithoutQuestions.Name}' topic must have at least one question.");
                }

                var questions = _themeModel.Topics
                    .Where(topic => topic.Questions != null)
                    .SelectMany(topic => topic.Questions)
                    .ToList();

                foreach (var questionWithoutAnswers in questions.Where(q => q.Answers == null || q.Answers.Count < 2))
                {
                    errors.AppendLine($"The '{questionWithoutAnswers.QuestionText}' must have at least 2 answers.");
                }

                foreach (var questionWithoutCorrectAnswer in questions.Where(q => q.Answers?.Count >= 2 && q.Answers.Count(a => a.IsCorrect) == 0))
                {
                    errors.AppendLine($"The '{questionWithoutCorrectAnswer.QuestionText}' must have at least 1 correct answer.");
                }
            }

            return errors.ToString();
        }
    }
}