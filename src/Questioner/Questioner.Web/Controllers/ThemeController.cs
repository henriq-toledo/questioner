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
                Topics = new List<TopicDetailViewModel>()
                {
                    new TopicDetailViewModel()
                    {
                        Name = "Topic 1",
                        QuestionsQuantity = 15,
                        Percentage = 20
                    },
                    new TopicDetailViewModel()
                    {
                        Name = "Topic 2",
                        QuestionsQuantity = 15,
                        Percentage = 20
                    },
                    new TopicDetailViewModel()
                    {
                        Name = "Topic 3",
                        QuestionsQuantity = 15,
                        Percentage = 25
                    },
                    new TopicDetailViewModel()
                    {
                        Name = "Topic 4",
                        QuestionsQuantity = 15,
                        Percentage = 35
                    }
                }
            });
        }

        public ActionResult Questioner(int id)
        {
            return View(new ThemeViewModel()
            {
                Name = "Exam AZ-900",
                Questions = new List<QuestionViewModel>()
                {
                    new QuestionViewModel()
                    {
                        Id = 1,                        
                        QuestionText = "Azure Web App is a PAAS service?",
                        Answers = new List<AnswerViewModel>()
                        {
                            new AnswerViewModel()
                            {
                                Id = 1,                                
                                AnswerText = "True"
                            },
                            new AnswerViewModel()
                            {
                                Id = 1,                                
                                AnswerText = "False"
                            }
                        }
                    },
                    new QuestionViewModel()
                    {
                        Id = 2,
                        QuestionText = "Azure Function is a PAAS service?",
                        Answers = new List<AnswerViewModel>()
                        {
                            new AnswerViewModel()
                            {
                                Id = 3,
                                AnswerText = "True"
                            },
                            new AnswerViewModel()
                            {
                                Id = 4,
                                AnswerText = "False"
                            }
                        }
                    }
                }
            });
        }
        
        [HttpPost]
        public ActionResult Result(ThemeViewModel theme)
        {
            return View();
        }
    }
}