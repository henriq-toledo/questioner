using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Classes.Entities;
using System.Threading.Tasks;

namespace Questioner.WebApi.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly Context context;

        public ThemeRepository(Context context)
        {
            this.context = context;
        }

        public async Task Create(Theme theme)
        {
            context.Themes.Add(theme);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int themeId)
        {
            var theme = await context.Themes.FindAsync(themeId);

            context.Themes.Remove(theme);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsTheme(int themeId)
            => await context.Themes.AnyAsync(theme => theme.Id == themeId);

        public async Task<Theme[]> GetAll(bool includeChildren = false)
        {
            var query = context.Themes.AsQueryable();

            if (includeChildren)
            {
                query = query
                    .Include(theme => theme.Topics)
                    .ThenInclude(topic => topic.Questions)
                    .ThenInclude(question => question.Answers);
            }

            return await query.ToArrayAsync();
        }
    }
}