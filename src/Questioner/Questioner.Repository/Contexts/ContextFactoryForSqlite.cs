using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Questioner.Repository.Contexts
{
    public class ContextFactoryForSqlite : IDesignTimeDbContextFactory<ContextForSqlite>
    {
        public ContextForSqlite CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ContextForSqlite> optionsBuilder = new();
            optionsBuilder.UseSqlite(@"Data Source=.\QUESTIONER_DB.db;");

            return new ContextForSqlite(optionsBuilder.Options);
        }
    }
}