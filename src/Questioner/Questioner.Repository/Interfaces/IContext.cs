using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Classes.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Questioner.Repository.Interfaces
{
    public interface IContext
    {
        DbSet<Theme> Themes { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<Link> Links { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}