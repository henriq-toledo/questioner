using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.WebApp.Services
{
    public interface IQuestionerWebApiService
    {
        Task<HttpResponseMessage> GetAsync();
    }
}
