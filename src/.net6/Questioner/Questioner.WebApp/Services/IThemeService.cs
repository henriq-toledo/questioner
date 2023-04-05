using Questioner.Repository.Entities;
using System.Threading.Tasks;

namespace Questioner.WebApp.Services
{
    public interface IThemeService
    {
        Task<Theme[]> GetAllThemes();

        Task<Theme> GetThemeById(int themeId);

        Task<bool> ExistsThemeById(int themeId);

    }
}
