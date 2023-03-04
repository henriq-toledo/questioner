using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Classes.Entities;
using System;

namespace Questioner.WebApi.Test.Framework.Factories
{
    public static class ContextFactory
    {
        public static Context Create()
            => new Context(new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
    }
}
