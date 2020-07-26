using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        [HttpGet]
        public ActionResult<Array> Get(bool includeChildren = false)
        {
            List<Theme> themes;

            if (includeChildren)
            {
                themes = _context.Themes
                    .Include(theme => theme.Topics)
                    .ThenInclude(topic => topic.Questions)
                    .ThenInclude(question => question.Answers)
                    .ToList();
            }
            else
            {
                themes = _context.Themes.ToList();
            }

            return themes.ToArray();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var theme = _context.Themes.Find(id);

            if (theme == null)
            {
                return NotFound();
            }

            try
            {
                _context.Themes.Remove(theme);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}