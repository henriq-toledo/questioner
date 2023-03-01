using Questioner.Web.Models;
using System.IO;

namespace Questioner.Web.Services
{
    public interface IReportExportService
    {
        MemoryStream Export(ResultViewModel resultViewModel);
    }
}
