using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Contexts;

namespace Questioner.WebApi.Test.Framework.Factories
{
    public static class ContextFactory
    {
        public static ContextForSqlServer CreateContextForSqlServer()
            => new ContextForSqlServer(new DbContextOptionsBuilder<ContextForSqlServer>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        public static ContextForSqlite CreateContextForSqlite()
            => new ContextForSqlite(new DbContextOptionsBuilder<ContextForSqlite>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
    }
}
