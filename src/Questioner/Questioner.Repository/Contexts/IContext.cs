using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Questioner.Repository.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Questioner.Repository.Contexts
{
    public interface IContext
    {
        DbSet<Theme> Themes { get; set; }

        DbSet<Topic> Topics { get; set; }

        DbSet<Question> Questions { get; set; }

        DbSet<Answer> Answers { get; set; }

        DbSet<Link> Links { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}