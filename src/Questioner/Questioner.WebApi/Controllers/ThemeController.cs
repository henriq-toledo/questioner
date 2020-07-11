using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Models;

namespace Questioner.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThemeController : ControllerBase
    {
        private readonly ILogger<ThemeController> _logger;
        private readonly Context _context;

        public ThemeController(ILogger<ThemeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public ActionResult Create([FromBody] ThemeModel theme)
        {
            var themeEntity = theme.ToEntity();

            _context.Themes.Add(themeEntity);
            _context.SaveChanges();

            return Ok();
        }
    }
}