using Questioner.Repository.Classes.Entities;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public interface IThemeService
    {
        Task<Theme[]> GetAllThemes();
        Task<Theme> GetThemeById(int themeId);
    }
}
