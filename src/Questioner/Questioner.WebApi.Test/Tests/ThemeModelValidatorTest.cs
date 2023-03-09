using FluentValidation.TestHelper;
using NUnit.Framework;
using Questioner.Repository.Entities;
using Questioner.WebApi.Models;
using Questioner.WebApi.Test.Framework.Constants;
using Questioner.WebApi.Test.Framework.Defaults;
using Questioner.WebApi.Test.Framework.Extensions;
using Questioner.WebApi.Test.Framework.Factories;
using Questioner.WebApi.Test.TestCases;
using System.Threading.Tasks;
using ContextFactory = Questioner.WebApi.Test.Framework.Factories.ContextFactory;

namespace Questioner.WebApi.Test.Tests
{
    [TestFixture]
    public class ThemeModelValidatorTest
    {
        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.ThemeWithoutNameShouldBeInvalidTestCase))]
        public async Task ThemeWithoutNameShouldBeInvalid(ThemeModel themeModel)
        {
            // Arrange            
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorCode(FluentValidationErrorCodeConstant.NotEmptyValidator);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.DuplicatedThemeNameShouldBeInvalidTestCase))]
        public async Task DuplicatedThemeNameShouldBeInvalid((Theme, ThemeModel) themePair)
        {
            // Arrange            
            var expectedErrorMessage = $"The '{ThemeNameDefault.Default}' theme already exists.";
            using var context = ContextFactory.CreateContextForSqlServer();            
            var themeModelValidator = ThemeModelValidatorFactory.Create(context);

            await context.InsertTheme(themePair.Item1);

            // Act
            var result = await themeModelValidator.TestValidateAsync(themePair.Item2);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorMessage(expectedErrorMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.ThemeWithoutTopicsShouldBeInvalidTestCase))]
        public async Task ThemeWithoutTopicsShouldBeInvalid(ThemeModel themeModel)
        {
            // Arrange
            var expectedErroMessage = "The theme must have at least one topic.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorMessage(expectedErroMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.SumFromTopicsPercentageDifferentFromOneHundredShouldBeInvalidTestCase))]
        public async Task SumFromTopicsPercentageDifferentFromOneHundredShouldBeInvalid(ThemeModel themeModel)
        {
            // Arrange
            var expectedErroMessage = "The sum of the all topics percentage must be 100.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.SumFromTopicsPercentageEqualOneHundredShouldBeValidTestCase))]
        public async Task SumFromTopicsPercentageEqualOneHundredShouldBeValid(ThemeModel themeModel)
        {
            // Arrange
            var expectedErroMessage = "The sum of the all topics percentage must be 100.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result.Errors.WithoutErrorMessage(expectedErroMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.TopicWithoutQuestionsShouldBeInvalidTestCase))]
        public async Task TopicWithoutQuestionsShouldBeInvalid(ThemeModel themeModel)
        {
            // Arrange            
            var expectedErroMessage = $"The '{TopicNameDefault.Default}' topic must have at least one question.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

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
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.QuestionWithoutCorrectAnswerShouldBeInvalidTestCase))]
        public async Task QuestionWithoutCorrectAnswerShouldBeInvalid(ThemeModel themeModel)
        {
            // Arrange            
            var expectedErroMessage = $"The '{QuestionTextDefault.Default}' question must have at least 1 correct answer.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result.ShouldHaveAnyValidationError().WithErrorMessage(expectedErroMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.ThemeWithPassRateOutsideRangeShouldBeInvalidTestCase))]
        public async Task ThemeWithPassRateOutsideRangeShouldBeInvalid(ThemeModel themeModel)
        {
            // Arrange
            var expectedErrorMessage = $"'Pass Rate' must be between 60 and 100. You entered {themeModel.PassRate}.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result
                .ShouldHaveAnyValidationError()
                .WithErrorCode(FluentValidationErrorCodeConstant.InclusiveBetweenValidator)
                .WithErrorMessage(expectedErrorMessage);
        }

        [Test]
        [TestCaseSource(typeof(ThemeModelValidatorTestCase), nameof(ThemeModelValidatorTestCase.ThemeWithPassRateInsideRangeShouldBeValidTestCase))]
        public async Task ThemeWithPassRateInsideRangeShouldBeValid(ThemeModel themeModel)
        {
            // Arrange
            var expectedErrorMessage = $"'Pass Rate' must be between 60 and 100. You entered {themeModel.PassRate}.";
            var themeModelValidator = ThemeModelValidatorFactory.Create();

            // Act
            var result = await themeModelValidator.TestValidateAsync(themeModel);

            // Assert
            result
                .Errors
                .WithoutErrorCode(FluentValidationErrorCodeConstant.InclusiveBetweenValidator)
                .WithoutErrorMessage(expectedErrorMessage);
        }
    }
}
