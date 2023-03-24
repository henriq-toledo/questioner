using System.Collections;

namespace Questioner.WebApi.Extensions
{
    public static class ObjectCollectionExtension
    {
        public static bool IsNullOrEmpty(this ICollection objects) => objects == null || objects.Count == 0;
    }
}
