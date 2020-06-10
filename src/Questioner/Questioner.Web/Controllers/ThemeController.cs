using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class ThemeController : Controller
    {
        private readonly ILogger<ThemeController> _logger;

        public ThemeController(ILogger<ThemeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Details(long id)
        {
            return View(new ThemeDetailViewModel()
            {
                Id = 1,
                Name = "Theme 1",
                Topics = new List<TopicViewModel>()
                {
                    new TopicViewModel()
                    {
                        Name = "Topic 1",
                        QuestionsQuantity = 15
                    },
                    new TopicViewModel()
                    {
                        Name = "Topic 2",
                        QuestionsQuantity = 15
                    },
                    new TopicViewModel()
                    {
                        Name = "Topic 3",
                        QuestionsQuantity = 15
                    },
                    new TopicViewModel()
                    {
                        Name = "Topic 4",
                        QuestionsQuantity = 15
                    }
                }
            });
        }
    }
}