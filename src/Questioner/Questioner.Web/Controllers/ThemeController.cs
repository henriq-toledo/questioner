using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
            return View(new ThemeDetailViewModel(context.Themes.AsQueryable().FirstOrDefault(t => t.Id == id)));
        }

        public ActionResult Questioner(int id)
        {
            return View(new ThemeViewModel(context.Themes.AsQueryable().FirstOrDefault(t => t.Id == id)));
        }
    }
}