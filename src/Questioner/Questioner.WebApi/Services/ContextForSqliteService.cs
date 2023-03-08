using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Services
{
    public class ContextForSqliteService : IContextService
    {
        private readonly Context context;

        public ContextForSqliteService(ContextForSqlite context)
        {
            this.context = context;
        }

        public Context GetContext() => context;
    }
}
