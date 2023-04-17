namespace Questioner.WebApp.Services
{
    public interface IQuestionerWebApiService
    {
        Task<HttpResponseMessage> GetAsync();
    }
}
