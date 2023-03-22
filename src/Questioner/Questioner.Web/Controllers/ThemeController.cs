using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questioner.Web.Models;
using Questioner.Web.Services;
using System.Threading.Tasks;

namespace Questioner.Web.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IThemeService themeService;

        public ThemeController(IThemeService themeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.themeService = themeService;
        }

        public async Task<ActionResult> Details(int id)
        {
            var theme = (await themeService.GetThemeById(id));

            if (theme == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ThemeDetailViewModel>(theme));
        }

        public async Task<ActionResult> Exam(int id)
        {
            var theme = await themeService.GetThemeById(id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(mapper.Map<ThemeViewModel>(theme));
        }
    }
}