using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Questioner.Repository.Contexts
{
    public class ContextFactoryForSqlServer : IDesignTimeDbContextFactory<ContextForSqlServer>
    {
        public ContextForSqlServer CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextForSqlServer>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=QUESTIONER_DB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ContextForSqlServer(optionsBuilder.Options);
        }
    }
}