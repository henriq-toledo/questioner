using Questioner.Repository.Entities;

namespace Questioner.WebApp.Repositories
{
    public interface IThemeRepository
    {
        Task<Theme[]> GetAllThemes();

        Task<Theme> GetThemeById(int themeId);

        Task<bool> ExistsThemeById(int themeId);
    }
}
