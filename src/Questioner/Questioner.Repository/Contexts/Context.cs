using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Entities;

namespace Questioner.Repository.Contexts
{
    public abstract class Context : DbContext, IContext
    {
        public virtual DbSet<Theme> Themes { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }

        public virtual DbSet<Link> Links { get; set; }

        protected Context(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>()
                .HasIndex(theme => theme.Name)
                .HasDatabaseName("UX_Theme_Name")
                .IsUnique();

            modelBuilder.Entity<Topic>()
                .HasIndex(topic => new { topic.ThemeId, topic.Name })
                .HasDatabaseName("UX_Topic_Name")
                .IsUnique();

            modelBuilder.Entity<Question>()
                .HasIndex(question => new { question.TopicId, question.QuestionText })
                .HasDatabaseName("UX_Question_QuestionText")
                .IsUnique();

            modelBuilder.Entity<Answer>()
                .HasIndex(answer => new { answer.QuestionId, answer.AnswerText })
                .HasDatabaseName("UX_Answer_AnswerText")
                .IsUnique();

            modelBuilder.Entity<Theme>()
                .Property(t => t.PassRate)
                .HasDefaultValue(80);
        }
    }
}