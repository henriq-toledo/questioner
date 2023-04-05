using Questioner.Repository.Contexts;
using Questioner.Repository.Entities;
using System.Threading.Tasks;

namespace Questioner.WebApi.Test.Framework.Extensions
{
    public static class ContextExtension
    {
        public static async Task InsertTheme(this Context context, Theme theme)
            => await context.InsertTheme(new[] { theme });

        public static async Task InsertTheme(this Context context, Theme[] themes)
        {
            context.Themes.AddRange(themes);
            await context.SaveChangesAsync();
        }
    }
}
