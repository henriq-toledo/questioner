using Questioner.Repository.Interfaces;

namespace Questioner.WebApi.Services
{
    public interface IContextService
    {
        IContext GetContext();
    }
}
