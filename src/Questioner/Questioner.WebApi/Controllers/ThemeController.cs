using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Classes.Entities;

namespace Questioner.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThemeController : ControllerBase
    {
        private readonly ILogger<ThemeController> _logger;

        public ThemeController(ILogger<ThemeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Create([FromBody] Theme theme)
        {
            return Ok();
        }
    }
}