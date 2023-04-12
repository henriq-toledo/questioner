using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Questioner.WebApp.Settings;
using System.Net.Http.Headers;

namespace Questioner.WebApp.Services
{
    public class QuestionerWebApiService : IQuestionerWebApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IOptions<QuestionerWebApiSettings> options;

        public QuestionerWebApiService(IOptions<QuestionerWebApiSettings> options, IHttpClientFactory httpClientFactory)
        {
            this.options = options;
            this.httpClientFactory = httpClientFactory;
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

            var client = httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(options.Value.Url);       
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);

            return client;
        }
    }
}
