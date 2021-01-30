using Microsoft.AspNetCore.Mvc;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IThemeService themeService;

        public HomeController(IThemeService themeService)
        {
            this.themeService = themeService;
        }

        public async Task<IActionResult> Index() 
            => View((await themeService.GetAllThemes()).Select(theme => new ThemeListViewModel(theme)).ToList());

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
