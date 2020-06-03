using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Interfaces;

namespace Questioner.Repository.Classes.Entities
{
    public class Context : DbContext, IContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("<connection string>");
        }
    }
}