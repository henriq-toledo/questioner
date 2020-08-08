using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Interfaces;
using Questioner.Web.Models;

namespace Questioner.Web.Controllers
{
    public class ThemeController : BaseController
    {
        public ThemeController(ILogger<ThemeController> logger, IContext context)
            : base(logger, context)
        {
        }

        public ActionResult Details(long id)
        {
            var theme = context.Themes
                .Include(theme => theme.Topics)
                .ThenInclude(topic => topic.Questions)
                .FirstOrDefault(t => t.Id == id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(new ThemeDetailViewModel(theme));
        }

        public ActionResult Questioner(int id)
        {
            var theme = context.Themes
                .Include(theme => theme.Topics)
                .ThenInclude(topic => topic.Questions)
                .ThenInclude(question => question.Answers)
                .FirstOrDefault(t => t.Id == id);

            if (theme == null)
            {
                return NotFound();
            }

            return View(new ThemeViewModel(theme));
        }
    }
}