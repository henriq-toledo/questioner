using Microsoft.EntityFrameworkCore;

namespace Questioner.Repository.Contexts
{
    public class ContextForSqlite : Context
    {
        public ContextForSqlite(DbContextOptions<ContextForSqlite> options) : base(options)
        {
        }
    }
}
