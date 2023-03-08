using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Questioner.Repository.Contexts
{
    public class ContextFactoryForSqlite : IDesignTimeDbContextFactory<ContextForSqlite>
    {
        public ContextForSqlite CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextForSqlite>();
            optionsBuilder.UseSqlite(@"Data Source=.\QUESTIONER_DB.db;");

            return new ContextForSqlite(optionsBuilder.Options);
        }
    }
}