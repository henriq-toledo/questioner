using Questioner.WebApp.Models;

namespace Questioner.WebApp.Services
{
    public interface IResultService
    {
        Task<ResultViewModel> Process(ThemeViewModel themeViewModel);
    }
}
