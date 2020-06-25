using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Interfaces;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger, IContext context)
         : base(logger, context)
        {
        }

        public IActionResult Index()
        {
            return View(context.Themes.AsQueryable().Select(theme => new ThemeListViewModel(theme)).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
