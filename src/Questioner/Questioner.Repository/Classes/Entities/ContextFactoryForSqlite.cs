using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Questioner.Repository.Classes.Entities
{
    public class ContextFactoryForSqlite : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlite(@"Data Source=.\QUESTIONER_DB.db;");

            return new Context(optionsBuilder.Options);
        }
    }
}