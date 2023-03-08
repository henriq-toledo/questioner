using Questioner.Repository.Entities;
using Questioner.WebApi.Repositories;
using System.Threading.Tasks;

namespace Questioner.WebApi.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository themeRepository;

        public ThemeService(IThemeRepository themeRepository)
        {
            this.themeRepository = themeRepository;
        }

        public async Task Create(Theme theme)
            => await themeRepository.Create(theme);

        public async Task Delete(int themeId)
            => await themeRepository.Delete(themeId);

        public async Task<bool> ExistsTheme(int themeId)
            => await themeRepository.ExistsTheme(themeId);

        public async Task<Theme[]> GetAll(bool includeChildren = false)
            => await themeRepository.GetAll(includeChildren);
    }
}