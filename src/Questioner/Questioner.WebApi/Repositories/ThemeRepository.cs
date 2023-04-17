using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Contexts;
using Questioner.Repository.Entities;
using Questioner.WebApi.Services;

namespace Questioner.WebApi.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly IContext context;

        public ThemeRepository(IContextService contextService)
        {
            context = contextService.GetContext();
        }

        public async Task Create(Theme theme)
        {
            context.Themes.Add(theme);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int themeId)
        {
            var theme = await context.Themes.FindAsync(themeId);

            if (theme is null) return;

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