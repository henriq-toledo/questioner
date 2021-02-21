using FluentValidation.TestHelper;
using NUnit.Framework;
using Questioner.WebApi.Models;
using Questioner.WebApi.UnitTest.Framework.Constants;
using Questioner.WebApi.UnitTest.Framework.Defaults;
using Questioner.WebApi.UnitTest.Framework.Extensions;
using Questioner.WebApi.UnitTest.Framework.Factories;
using Questioner.WebApi.UnitTest.TestCases;
using Questioner.WebApi.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questioner.WebApi.UnitTest.Tests.Validators
{
    [TestFixture]
    public class ThemeModelValidatorTest
    {
        [Test]
        public async Task NullThemeNameShouldBeInvalid()
        {
            // Arrange            
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(new ThemeModel { Name = null });

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorCode(FluentValidationErrorCodeConstant.NotEmptyValidator);
        }

        [Test]
        public async Task EmptyThemeNameShouldBeInvalid()
        {
            // Arrange
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(new ThemeModel { Name = string.Empty });

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorCode(FluentValidationErrorCodeConstant.NotEmptyValidator);
        }

        [Test]
        public async Task DuplicatedThemeNameShouldBeInvalid()
        {
            // Arrange
            var themeName = "Test";
            var expectedErrorMessage = $"The '{themeName}' theme already exists.";
            var theme = new Repository.Classes.Entities.Theme { Name = themeName };
            var themeModel = new ThemeModel { Name = themeName };
            var context = ContextFactory.Create();
            var themeModelValidator = new ThemeModelValidator(context);

            await context.InsertTheme(theme);

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorMessage(expectedErrorMessage);
        }

        [Test]
        public async Task EmptyTopicsShouldBeInvalid()
        {
            // Arrange
            var expectedErroMessage = "The theme must have at least one topic.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithEmptyTopics = new ThemeModel { Topics = new List<TopicModel>() };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithEmptyTopics);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task NullTopicsShouldBeInvalid()
        {
            // Arrange
            var expectedErroMessage = "The theme must have at least one topic.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithNullTopics = new ThemeModel { Topics = null };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithNullTopics);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task SumFromTopicsPercentageShouldNotBeLessThanOneHundred()
        {
            // Arrange
            var expectedErroMessage = "The sum of the all topics percentage must be 100.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithTopicsPercentageLessThanOneHundred = new ThemeModel
            {
                Topics = new List<TopicModel>
                {
                    new TopicModel { Percentage = 25 },
                    new TopicModel { Percentage = 50 }
                }
            };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithTopicsPercentageLessThanOneHundred);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task SumFromTopicsPercentageShouldNotBeMoreThanOneHundred()
        {
            // Arrange
            var expectedErroMessage = "The sum of the all topics percentage must be 100.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithTopicsPercentageMoreThanOneHundred = new ThemeModel
            {
                Topics = new List<TopicModel>
                {
                    new TopicModel { Percentage = 75 },
                    new TopicModel { Percentage = 50 }
                }
            };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithTopicsPercentageMoreThanOneHundred);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task SumFromTopicsPercentageEqualOneHundredShouldBeValid()
        {
            // Arrange
            var expectedErroMessage = "The sum of the all topics percentage must be 100.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithTopicsPercentageMoreThanOneHundred = new ThemeModel
            {
                Topics = new List<TopicModel>
                {
                    new TopicModel { Percentage = 50 },
                    new TopicModel { Percentage = 50 }
                }
            };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithTopicsPercentageMoreThanOneHundred);

            // Assert
            result.ShouldHaveAnyValidationError().WithoutErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task TopicWithNullQuestionsShouldBeInvalid()
        {
            // Arrange
            var topicName = "Topic";
            var expectedErroMessage = $"The '{topicName}' topic must have at least one question.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithTopicWithNullQuestions = new ThemeModel
            {
                Topics = new List<TopicModel> { new TopicModel { Name = topicName, Questions = null } }
            };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithTopicWithNullQuestions);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task TopicWithEmptyQuestionsShouldBeInvalid()
        {
            // Arrange
            var topicName = "Topic";
            var expectedErroMessage = $"The '{topicName}' topic must have at least one question.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithTopicWithEmptyQuestions = new ThemeModel
            {
                Topics = new List<TopicModel> { new TopicModel { Name = topicName, Questions = new List<QuestionModel>() } }
            };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithTopicWithEmptyQuestions);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.QuestionShouldHaveAtLeastTwoAnswersTestCase))]
        public async Task QuestionShouldHaveAtLeastTwoAnswers(ThemeModel themeModel)
        {
            // Arrange            
            var expectedErroMessage = $"The '{QuestionTextDefault.Default}' question must have at least 2 answers.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        public async Task QuestionWithoutCorrectAnswerShouldBeInvalid()
        {
            // Arrange
            var questionText = "Question 1";
            var expectedErroMessage = $"The '{questionText}' question must have at least 1 correct answer.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();
            var themeWithQuestionWithoutCorrectAnswer = new ThemeModel
            {
                Topics = new List<TopicModel>
                {
                    new TopicModel
                    {
                        Questions = new List<QuestionModel>
                        {
                            new QuestionModel
                            {
                                QuestionText = questionText,
                                Answers = new List<AnswerModel>
                                {
                                    new AnswerModel
                                    {
                                        IsCorrect = false
                                    },
                                    new AnswerModel
                                    {
                                        IsCorrect = false
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeWithQuestionWithoutCorrectAnswer);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }
    }
}
