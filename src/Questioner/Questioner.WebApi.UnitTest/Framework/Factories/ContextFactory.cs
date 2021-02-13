using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Classes.Entities;
using System;

namespace Questioner.WebApi.UnitTest.Framework.Factories
{
    public static class ContextFactory
    {
        public static Context CreateContext()
            => new Context(new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
    }
}
