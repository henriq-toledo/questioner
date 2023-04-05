using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Questioner.Repository.Entities;
using Questioner.WebApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.WebApp.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private Theme[] themes;
        private readonly ILogger logger;
        private readonly IQuestionerWebApiService questionerWebApiService;

        public ThemeRepository(ILogger<ThemeRepository> logger, IQuestionerWebApiService questionerWebApiService)
        {            
            this.logger = logger;
            this.questionerWebApiService = questionerWebApiService;

            themes = new Theme[] { };
        }

        public async Task<bool> ExistsThemeById(int themeId) 
            => (await GetAllThemes()).Any(theme => theme.Id == themeId);

        public async Task<Theme[]> GetAllThemes()
        {
            try
            {                
                var responseMessage = await questionerWebApiService.GetAsync();

                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                {
                    themes = JsonConvert.DeserializeObject<Theme[]>(content);
                }
                else
                {                    
                    logger.LogError($"Status Code: {responseMessage.StatusCode}, Reason Phrase: {responseMessage.ReasonPhrase}, Content: {content}");
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
