using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Questioner.WebApp.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Questioner.WebApp.Services
{
    public class QuestionerWebApiService : IQuestionerWebApiService
    {
        private readonly IOptions<QuestionerWebApiSettings> options;

        public QuestionerWebApiService(IOptions<QuestionerWebApiSettings> options)
        {
            this.options = options;
        }

        public async Task<HttpResponseMessage> GetAsync()
        {
            using HttpClient client = await CreateHttpClient();

            return await client.GetAsync($"theme?includeChildren=true");
        }

        private async Task<HttpClient> CreateHttpClient()
        {
            var confidentialClientApplication = ConfidentialClientApplicationBuilder
                            .Create(clientId: options.Value.ClientId)
                            .WithClientSecret(clientSecret: options.Value.ClientSecret)
                            .WithTenantId(tenantId: options.Value.TenantId)
                            .Build();

            var scope = $"api://{options.Value.ClientId}/.default";
            var authenticationResult = await confidentialClientApplication
                .AcquireTokenForClient(new string[] { scope })
                .ExecuteAsync();

            var client = new HttpClient
            {
                BaseAddress = new Uri(options.Value.Url)
            };            
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);

            return client;
        }
    }
}
