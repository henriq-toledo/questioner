using Microsoft.AspNetCore.Mvc;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.Threading.Tasks;

namespace Questioner.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly IThemeService themeService;
        private readonly IResultService resultService;

        public ResultController(IThemeService themeService, IResultService resultService)
        {
            this.themeService = themeService;
            this.resultService = resultService;
        }

        public async Task<ActionResult> Details(ThemeViewModel themeViewModel)
        {
            if (await themeService.ExistsThemeById(themeViewModel.Id) == false)
            {
                return NotFound();
            }

            var model = await resultService.Process(themeViewModel);

            return View(model);
        }

        [HttpPost]
        public ActionResult Export(ResultViewModel result)
        {
            using var stream = resultService.Export(result);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "result.xlsx");
        }
    }
}