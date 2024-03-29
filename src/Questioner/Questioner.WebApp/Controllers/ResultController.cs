using Microsoft.AspNetCore.Mvc;
using Questioner.WebApp.Models;
using Questioner.WebApp.Services;

namespace Questioner.WebApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly IThemeService themeService;
        private readonly IResultService resultService;
        private readonly IReportExportService reportExportService;

        public ResultController(IThemeService themeService, IResultService resultService, IReportExportService reportExportService)
        {
            this.themeService = themeService;
            this.resultService = resultService;
            this.reportExportService = reportExportService;
        }

        public async Task<ActionResult> Details(ThemeViewModel themeViewModel)
        {
            if (!await themeService.ExistsThemeById(themeViewModel.Id))
            {
                return NotFound();
            }

            var model = await resultService.Process(themeViewModel);

            return View(model);
        }

        [HttpPost]
        public ActionResult Export(ResultViewModel resultViewModel)
        {
            using var stream = reportExportService.Export(resultViewModel);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "result.xlsx");
        }
    }
}