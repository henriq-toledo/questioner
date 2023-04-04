using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Services
{
    public class ContextForSqliteService : ContextService
    {
        public ContextForSqliteService(ContextForSqlite context) : base(context)
        {
        }
    }
}
