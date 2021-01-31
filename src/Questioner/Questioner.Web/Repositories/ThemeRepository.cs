using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Questioner.Repository.Classes.Entities;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly AppSettings appSettings;
        private readonly ILogger logger;
        private Theme[] themes;

        public ThemeRepository(IOptions<AppSettings> options, ILogger<ThemeRepository> logger)
        {
            appSettings = options.Value;
            this.logger = logger;
            themes = new Theme[] { };
        }

        public async Task<bool> ExistsThemeById(int themeId) 
            => (await GetAllThemes()).Any(theme => theme.Id == themeId);

        public async Task<Theme[]> GetAllThemes()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var responseMessage = await client.GetAsync(appSettings.QuestionerWebApiUrl + "theme?includeChildren=true");
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    themes = JsonConvert.DeserializeObject<Theme[]>(content);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }

            return themes;
        }

        public async Task<Theme> GetThemeById(int themeId)
            => (await GetAllThemes()).FirstOrDefault(Theme => Theme.Id == themeId);
    }
}
