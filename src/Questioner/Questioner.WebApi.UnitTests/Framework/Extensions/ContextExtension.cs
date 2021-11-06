using Questioner.Repository.Classes.Entities;
using System.Threading.Tasks;

namespace Questioner.WebApi.UnitTests.Framework.Extensions
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
