using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Interfaces;

namespace Questioner.Repository.Classes.Entities
{
    public class Context : DbContext, IContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("<connection string>");
        }
    }
}