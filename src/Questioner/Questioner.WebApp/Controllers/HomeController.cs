using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questioner.WebApp.Models;
using Questioner.WebApp.Services;
using System.Diagnostics;

namespace Questioner.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IThemeService themeService;

        public HomeController(IThemeService themeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.themeService = themeService;
        }

        public async Task<IActionResult> Index() 
            => View((await themeService.GetAllThemes()).Select(theme => mapper.Map<ThemeListViewModel>(theme)).ToList());

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
