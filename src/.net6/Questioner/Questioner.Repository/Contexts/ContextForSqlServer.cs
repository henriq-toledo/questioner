using Microsoft.EntityFrameworkCore;

namespace Questioner.Repository.Contexts
{
    public class ContextForSqlServer : Context
    {
        public ContextForSqlServer(DbContextOptions<ContextForSqlServer> options) : base(options)
        {
        }
    }
}
