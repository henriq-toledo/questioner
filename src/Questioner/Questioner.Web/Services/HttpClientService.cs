using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            using var client = new HttpClient();

            return await client.GetAsync(requestUri);
        }
    }
}
