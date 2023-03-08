using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Services
{
    public class ContextForSqlServerService : IContextService
    {
        private readonly Context context;

        public ContextForSqlServerService(ContextForSqlServer context)
        {
            this.context = context;
        }

        public Context GetContext() => context;
    }
}
