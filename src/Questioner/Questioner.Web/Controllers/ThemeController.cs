using Microsoft.AspNetCore.Mvc;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.Web.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeService themeService;

        public ThemeController(IThemeService themeService)
        {
            this.themeService = themeService;
        }

        public async Task<ActionResult> Details(long id)
        {
            var theme = (await themeService.GetAllThemes()).FirstOrDefault(t => t.Id == id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(new ThemeDetailViewModel(theme));
        }

        public async Task<ActionResult> Questioner(int id)
        {
            var theme = (await themeService.GetAllThemes()).FirstOrDefault(t => t.Id == id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(new ThemeViewModel(theme));
        }
    }
}