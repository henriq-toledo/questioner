using Questioner.WebApp.Models;
using System.IO;

namespace Questioner.WebApp.Services
{
    public interface IReportExportService
    {
        MemoryStream Export(ResultViewModel resultViewModel);
    }
}
