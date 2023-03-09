using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Services
{
    public class ContextForSqlServerService : ContextService
    {
        public ContextForSqlServerService(ContextForSqlServer context) : base(context)
        {
        }
    }
}
