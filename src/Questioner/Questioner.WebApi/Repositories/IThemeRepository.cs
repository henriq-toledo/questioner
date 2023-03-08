using Questioner.Repository.Entities;
using System.Threading.Tasks;

namespace Questioner.WebApi.Repositories
{
    public interface IThemeRepository
    {
        Task Create(Theme theme);
        Task<Theme[]> GetAll(bool includeChildren = false);
        Task Delete(int themeId);
        Task<bool> ExistsTheme(int themeId);
    }
}