using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Contexts;
using System;

namespace Questioner.WebApi.Test.Framework.Factories
{
    public static class ContextFactory
    {
        public static Context Create()
            => new ContextForSqlServer(new DbContextOptionsBuilder<ContextForSqlServer>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
    }
}
