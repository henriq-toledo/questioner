using Microsoft.AspNetCore.Mvc;
using Questioner.WebApi.Models;
using Questioner.WebApi.Services;
using Questioner.WebApi.Validators;
using System;
using System.Threading.Tasks;

namespace Questioner.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThemeController : ControllerBase
    {
        private readonly IThemeService themeService;

        public ThemeController(IThemeService themeService)
        {
            this.themeService = themeService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ThemeModel themeModel)
        {
            var themeValidator = new ThemeValidator(themeModel);
            var errors = themeValidator.Validate();
            var noErrors = string.IsNullOrEmpty(errors);

            if (noErrors)
            {
                var themeEntity = themeModel.ToEntity();

                await themeService.Create(themeEntity);

                return Ok();
            }
            else
            {
                return new BadRequestObjectResult(errors);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Array>> Get(bool includeChildren = false)
            => await themeService.GetAll(includeChildren);

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if ((await themeService.ExistsTheme(id)) == false) return NotFound();

            try
            {
                await themeService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}