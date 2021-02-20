using FluentValidation.TestHelper;
using NUnit.Framework;
using Questioner.WebApi.Models;
using Questioner.WebApi.UnitTest.Framework.Constants;
using Questioner.WebApi.UnitTest.Framework.Extensions;
using Questioner.WebApi.UnitTest.Framework.Factories;
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
                .ShouldHaveValidationErrorFor(theme => theme.Name)
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
                .ShouldHaveValidationErrorFor(theme => theme.Name)
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
                .ShouldHaveValidationErrorFor(theme => theme.Name)
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
                .ShouldHaveValidationErrorFor(theme => theme.Topics)
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
                .ShouldHaveValidationErrorFor(theme => theme.Topics)
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
    }
}
