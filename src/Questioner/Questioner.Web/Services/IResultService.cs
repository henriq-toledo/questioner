using Questioner.Web.Models;
using System.IO;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public interface IResultService
    {
        Task<ResultViewModel> Process(ThemeViewModel themeViewModel);
        MemoryStream Export(ResultViewModel resultViewModel);
    }
}
