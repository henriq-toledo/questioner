using Questioner.Repository.Entities;
using System.Threading.Tasks;

namespace Questioner.WebApp.Repositories
{
    public interface IThemeRepository
    {
        Task<Theme[]> GetAllThemes();

        Task<Theme> GetThemeById(int themeId);

        Task<bool> ExistsThemeById(int themeId);
    }
}
