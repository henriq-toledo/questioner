using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new List<ThemeViewModel>()
            {
                new ThemeViewModel()
                {
                    Id = 1,
                    Name = "Theme 1",
                    TopicsQuantity = 4,
                    QuestionsQuantity = 60
                },
                new ThemeViewModel()
                {
                    Id = 2,
                    Name = "Theme 2",
                    TopicsQuantity = 3,
                    QuestionsQuantity = 45
                }
            });
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
