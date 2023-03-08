using Moq;
using Questioner.Repository.Contexts;
using Questioner.WebApi.Services;
using Questioner.WebApi.Validators;

namespace Questioner.WebApi.Test.Framework.Factories
{
    public static class ThemeModelValidatorFactory
    {
        public static ThemeModelValidator Create()
        {            
            var context = ContextFactory.Create();
            var contextServiceMock = new Mock<IContextService>();
            contextServiceMock.Setup(m => m.GetContext()).Returns(context);

            var themeModelValidator = new ThemeModelValidator(contextServiceMock.Object);

            return themeModelValidator;
        }

        public static ThemeModelValidator Create(Context context)
        {
            var contextServiceMock = new Mock<IContextService>();
            contextServiceMock.Setup(m => m.GetContext()).Returns(context);

            var themeModelValidator = new ThemeModelValidator(contextServiceMock.Object);

            return themeModelValidator;
        }
    }
}
