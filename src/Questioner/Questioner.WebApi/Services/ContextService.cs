using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Services
{
    public abstract class ContextService : IContextService
    {
        private readonly IContext context;

        protected ContextService(IContext context)
        {
            this.context = context;
        }

        public IContext GetContext() => context;
    }
}
