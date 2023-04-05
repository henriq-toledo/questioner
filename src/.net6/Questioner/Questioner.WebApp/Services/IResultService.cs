using Questioner.WebApp.Models;
using System.Threading.Tasks;

namespace Questioner.WebApp.Services
{
    public interface IResultService
    {
        Task<ResultViewModel> Process(ThemeViewModel themeViewModel);
    }
}
