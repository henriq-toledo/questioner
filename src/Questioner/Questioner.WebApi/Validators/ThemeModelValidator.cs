﻿using FluentValidation;
using Questioner.WebApi.Constants;
using Questioner.WebApi.Models;
using Questioner.WebApi.Services;

namespace Questioner.WebApi.Validators
{
    public class ThemeModelValidator : AbstractValidator<ThemeModel>
    {
        public ThemeModelValidator(IContextService contextService)
        {
            var context = contextService.GetContext();

            RuleFor(theme => theme.Name)
                .NotEmpty()
                .Custom((themeName, customContext) => 
                {
                    if (context.Themes.Any(t => t.Name == themeName))
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

                    foreach (var questionWithoutAnswers in questions.Where(q => q.Answers?.Count == 1))
                    {
                        customContext.AddFailure($"The '{questionWithoutAnswers.QuestionText}' question must have zero or null, two or more answers. When zero or null, the default answers will be True and False.");
                    }

                    foreach (var questionWithoutCorrectAnswer in questions.Where(q => q.Answers?.Count >= 2 && !q.Answers.Any(a => a.IsCorrect)))
                    {
                        customContext.AddFailure($"The '{questionWithoutCorrectAnswer.QuestionText}' question must have at least 1 correct answer.");
                    }
                });
        }
    }
}
