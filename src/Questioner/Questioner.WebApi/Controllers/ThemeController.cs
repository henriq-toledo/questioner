using Microsoft.AspNetCore.Mvc;
using Questioner.Repository.Entities;
using Questioner.WebApi.Models;
using Questioner.WebApi.Services;
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
            var themeEntity = themeModel.ToEntity();

            await themeService.Create(themeEntity);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Theme[]>> Get(bool includeChildren = false)
            => await themeService.GetAll(includeChildren);

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!await themeService.ExistsTheme(id)) return NotFound();

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