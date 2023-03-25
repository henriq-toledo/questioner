using Microsoft.Identity.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            var confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(clientId: "")
                .WithClientSecret(clientSecret: "")
                .WithTenantId(tenantId: "")
                .Build();

            var authenticationResult = await confidentialClientApplication.AcquireTokenForClient(new string [] { "api://{clientId}/.default" }).ExecuteAsync();            

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);

            return await client.GetAsync(requestUri);
        }
    }
}
