using FluentValidation.TestHelper;
using NUnit.Framework;
using Questioner.WebApi.Models;
using Questioner.WebApi.UnitTest.Framework.Constants;
using Questioner.WebApi.UnitTest.Framework.Extensions;
using Questioner.WebApi.UnitTest.Framework.Factories;
using Questioner.WebApi.Validators;
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
    }
}
