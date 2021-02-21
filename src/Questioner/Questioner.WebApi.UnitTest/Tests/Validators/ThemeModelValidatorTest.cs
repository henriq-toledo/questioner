using FluentValidation.TestHelper;
using NUnit.Framework;
using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Models;
using Questioner.WebApi.UnitTest.Framework.Constants;
using Questioner.WebApi.UnitTest.Framework.Defaults;
using Questioner.WebApi.UnitTest.Framework.Extensions;
using Questioner.WebApi.UnitTest.Framework.Factories;
using Questioner.WebApi.UnitTest.TestCases;
using Questioner.WebApi.Validators;
using System.Threading.Tasks;
using ContextFactory = Questioner.WebApi.UnitTest.Framework.Factories.ContextFactory;

namespace Questioner.WebApi.UnitTest.Tests.Validators
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
            var context = ContextFactory.Create();
            var themeModelValidator = new ThemeModelValidator(context);

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
            result.ShouldHaveAnyValidationError().WithoutErrorMessage(expectedErroMessage);
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
    }
}
