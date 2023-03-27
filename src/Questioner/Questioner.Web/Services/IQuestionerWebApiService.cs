using System.Net.Http;
using System.Threading.Tasks;

namespace Questioner.Web.Services
{
    public interface IQuestionerWebApiService
    {
        Task<HttpResponseMessage> GetAsync();
    }
}
