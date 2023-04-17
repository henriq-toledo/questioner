using Questioner.Repository.Entities;

namespace Questioner.WebApi.Services
{
    public interface IThemeService
    {
        Task Create(Theme theme);

        Task<Theme[]> GetAll(bool includeChildren = false);

        Task Delete(int themeId);

        Task<bool> ExistsTheme(int themeId);
    }
}