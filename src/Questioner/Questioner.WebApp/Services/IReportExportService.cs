using Questioner.WebApp.Models;

namespace Questioner.WebApp.Services
{
    public interface IReportExportService
    {
        MemoryStream Export(ResultViewModel resultViewModel);
    }
}
