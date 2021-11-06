using Questioner.WebApi.Validators;

namespace Questioner.WebApi.UnitTests.Framework.Factories
{
    public static class ThemeModelValidatorFactory
    {
        public static ThemeModelValidator Create()
        {
            var context = ContextFactory.Create();
            var themeModelValidator = new ThemeModelValidator(context);

            return themeModelValidator;
        }
    }
}
