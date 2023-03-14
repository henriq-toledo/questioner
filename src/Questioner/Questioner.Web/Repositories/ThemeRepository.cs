﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Questioner.Repository.Entities;
using Questioner.Web.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.Web.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly AppSettings appSettings;
        private readonly ILogger logger;
        private readonly IHttpClientService httpClientService;
        private Theme[] themes;

        public ThemeRepository(IOptions<AppSettings> options, ILogger<ThemeRepository> logger, IHttpClientService httpClientService)
        {
            appSettings = options.Value;
            
            this.logger = logger;
            this.httpClientService = httpClientService;

            themes = new Theme[] { };
        }

        public async Task<bool> ExistsThemeById(int themeId) 
            => (await GetAllThemes()).Any(theme => theme.Id == themeId);

        public async Task<Theme[]> GetAllThemes()
        {
            try
            {                
                var responseMessage = await httpClientService.GetAsync(appSettings.QuestionerWebApiUrl + "theme?includeChildren=true");
                var content = await responseMessage.Content.ReadAsStringAsync();
                themes = JsonConvert.DeserializeObject<Theme[]>(content);
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
