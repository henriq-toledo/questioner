
using Questioner.Repository.Classes.Entities;
using System.Threading.Tasks;

namespace Questioner.Web.Repositories
{
    public interface IQuestionerRepository
    {
        Task<Theme[]> GetAllThemes();
        Task<Theme> GetThemeById(int themeId);
    }
}
