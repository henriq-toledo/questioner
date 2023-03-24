using AutoMapper;
using Questioner.WebApi.Controllers;
using Questioner.WebApi.Mapper;
using Questioner.WebApi.Repositories;
using Questioner.WebApi.Services;

namespace Questioner.WebApi.Test.Framework.Factories
{
    public static class ThemeControllerFactory
    {
        public static ThemeController Create(IContextService contextService)
        {
            var themeRepository = new ThemeRepository(contextService);
            var themeService = new ThemeService(themeRepository);
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>()).CreateMapper();
            var themeController = new ThemeController(themeService, mapper);

            return themeController;
        }
    }
}
