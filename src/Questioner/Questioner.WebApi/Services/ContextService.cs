using Questioner.Repository.Classes.Entities;
using Questioner.Repository.Interfaces;

namespace Questioner.WebApi.Services
{
    public class ContextService : IContextService
    {
        private readonly Context context;

        public ContextService(Context context)
        {
            this.context = context;
        }

        public IContext GetContext() => context;
    }
}
