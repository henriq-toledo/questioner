using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class ResultController : Controller
    {
        private readonly ILogger<ResultController> _logger;

        public ResultController(ILogger<ResultController> logger)
        {
            _logger = logger;
        }

        public ActionResult Details()
        {
            return View(new ResultViewModel()
            {
                ThemeId = 1,
                ThemeName = "Exam AZ-900",
                Percentage = 20,
                Topics = new List<TopicResultViewModel>()
                {
                    new TopicResultViewModel()
                    {
                        Id = 1,
                        Name = "",
                        Percentage = 15,
                        PercentageAnswered = 10
                    },
                    new TopicResultViewModel()
                    {
                        Id = 2,
                        Name = "",
                        Percentage = 15,
                        PercentageAnswered = 10
                    },
                    new TopicResultViewModel()
                    {
                        Id = 3,
                        Name = "",
                        Percentage = 20,
                        PercentageAnswered = 15
                    },
                    new TopicResultViewModel()
                    {
                        Id = 4,
                        Name = "",
                        Percentage = 35,
                        PercentageAnswered = 30
                    }
                },
                Questions = new List<QuestionResultViewModel>()
                {
                    new QuestionResultViewModel()
                    {
                        Id = 1,
                        QuestionText = "",
                        IsCorrect = true
                    },
                    new QuestionResultViewModel()
                    {
                        Id = 2,
                        QuestionText = "",
                        IsCorrect = false
                    }
                }
            });
        }
    }
}