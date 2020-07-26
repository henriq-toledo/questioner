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

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>()
                .HasIndex(theme => theme.Name)
                .HasName("UX_Theme_Name")
                .IsUnique();

            modelBuilder.Entity<Topic>()
                .HasIndex(topic => new { topic.ThemeId, topic.Name })
                .HasName("UX_Topic_Name")
                .IsUnique();

            modelBuilder.Entity<Question>()
                .HasIndex(question => new { question.TopicId, question.QuestionText })
                .HasName("UX_Question_QuestionText")
                .IsUnique();

            modelBuilder.Entity<Answer>()
                .HasIndex(answer => new { answer.QuestionId, answer.AnswerText })
                .HasName("UX_Answer_AnswerText")
                .IsUnique();
        }
    }
}