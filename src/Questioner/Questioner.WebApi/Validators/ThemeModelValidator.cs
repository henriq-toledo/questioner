using FluentValidation;
using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Constants;
using Questioner.WebApi.Models;
using System.Linq;

namespace Questioner.WebApi.Validators
{
    public class ThemeModelValidator : AbstractValidator<ThemeModel>
    {
        private readonly Context context;

        public ThemeModelValidator(Context context)
        {
            this.context = context;

            RuleFor(theme => theme.Name)
                .NotEmpty()
                .Custom((themeName, customContext) => 
                {
                    if (this.context.Themes.Any(t => t.Name == themeName))
                    {
                        customContext.AddFailure($"The '{themeName}' theme already exists.");
                    }
                });

            RuleFor(theme => theme.PassRate)
                .InclusiveBetween(ThemeConstant.MinPassRate, ThemeConstant.MaxPassRate);

            RuleFor(theme => theme.Topics)
                .NotEmpty()
                .WithMessage("The theme must have at least one topic.");

            RuleFor(theme => theme)
                .Must(theme => theme?.Topics.Sum(topic => topic.Percentage) == 100)
                .When(theme => ((theme?.Topics)?.Count).GetValueOrDefault() > 0)
                .WithMessage("The sum of the all topics percentage must be 100.");

            RuleForEach(theme => theme.Topics)
                .Must(topic => topic.Questions?.Count > 0)
                .When(theme => ((theme?.Topics)?.Count).GetValueOrDefault() > 0)
                .WithMessage((theme, topicWithoutQuestion) => $"The '{topicWithoutQuestion.Name}' topic must have at least one question.");

            RuleFor(theme => theme.Topics)
                .Custom((topics, customContext) =>
                {
                    if (topics == null) return;

                    var questions = topics
                        .Where(topic => topic.Questions != null)
                        .SelectMany(topic => topic.Questions)
                        .ToArray();

                    foreach (var questionWithoutAnswers in questions.Where(q => q.Answers == null || q.Answers.Count < 2))
                    {
                        customContext.AddFailure($"The '{questionWithoutAnswers.QuestionText}' question must have at least 2 answers.");
                    }

                    foreach (var questionWithoutCorrectAnswer in questions.Where(q => q.Answers?.Count >= 2 && q.Answers.Count(a => a.IsCorrect) == 0))
                    {
                        customContext.AddFailure($"The '{questionWithoutCorrectAnswer.QuestionText}' question must have at least 1 correct answer.");
                    }
                });
        }
    }
}
