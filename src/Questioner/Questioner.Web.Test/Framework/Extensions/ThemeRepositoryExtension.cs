using Questioner.Repository.Entities;
using Questioner.Web.Repositories;
using System.Reflection;

namespace Questioner.Web.Test.Framework.Extensions
{
    internal static class ThemeRepositoryExtension
    {
        public static void SetThemes(this ThemeRepository themeRepository, Theme[] themes)
            => themeRepository
            .GetType()
            .GetField(nameof(themes), BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(themeRepository, themes);
    }
}
