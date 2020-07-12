using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Models;
using Questioner.WebApi.Validators;

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
        public ActionResult Create([FromBody] ThemeModel themeModel)
        {
            var themeValidator = new ThemeValidator(themeModel);
            var errors = themeValidator.Validate();
            var noErrors = string.IsNullOrEmpty(errors);

            if (noErrors)
            {
                var themeEntity = themeModel.ToEntity();

                _context.Themes.Add(themeEntity);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(errors);
            }
        }
    }
}