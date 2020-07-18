using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Questioner.Repository.Classes.Entities
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=QUESTIONER_DB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new Context(optionsBuilder.Options);
        }
    }
}