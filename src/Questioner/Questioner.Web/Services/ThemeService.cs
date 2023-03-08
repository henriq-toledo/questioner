using Questioner.Repository.Entities;
using Questioner.Web.Repositories;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository themeRepository;

        public ThemeService(IThemeRepository themeRepository)
        {
            this.themeRepository = themeRepository;
        }

        public async Task<bool> ExistsThemeById(int themeId) => await themeRepository.ExistsThemeById(themeId);

        public async Task<Theme[]> GetAllThemes() => await themeRepository.GetAllThemes();

        public async Task<Theme> GetThemeById(int themeId) => await themeRepository.GetThemeById(themeId);
    }
}
