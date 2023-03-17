using System.IO;
using System.Reflection;

namespace Questioner.Web.Test.Framework.Helpers
{
    internal static class FileNameHelper
    {
        public static string GetExpectedReportFileName()
            => Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Framework", "Files", "ExpectedReport.xlsx");
    }
}
