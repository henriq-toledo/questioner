using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
