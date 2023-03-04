using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Controllers;
using Questioner.WebApi.Repositories;
using Questioner.WebApi.Services;

namespace Questioner.WebApi.Test.Framework.Factories
{
    public static class ThemeControllerFactory
    {
        public static ThemeController Create(Context context)
        {
            var themeRepository = new ThemeRepository(context);
            var themeService = new ThemeService(themeRepository);
            var themeController = new ThemeController(themeService);

            return themeController;
        }
    }
}
