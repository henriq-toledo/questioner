using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Questioner.Repository.Classes.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Repositories
{
    public class QuestionerRepository : IQuestionerRepository
    {
        private readonly AppSettings appSettings;
        private readonly ILogger logger;
        private Theme[] themes;

        public QuestionerRepository(IOptions<AppSettings> options, ILogger<QuestionerRepository> logger)
        {
            appSettings = options.Value;
            this.logger = logger;
            themes = new Theme[] { };
        }

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
    }
}
