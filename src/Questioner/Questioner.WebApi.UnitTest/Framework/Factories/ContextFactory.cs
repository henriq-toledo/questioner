using Microsoft.EntityFrameworkCore;
using Questioner.Repository.Classes.Entities;

namespace Questioner.WebApi.UnitTest.Framework.Factories
{
    public static class ContextFactory
    {
        public static Context CreateContext()
            => new Context(new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("QuestionerDB").Options);
    }
}
