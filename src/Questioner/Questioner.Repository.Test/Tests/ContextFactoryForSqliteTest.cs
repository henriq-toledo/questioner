using NUnit.Framework;
using Questioner.Repository.Contexts;

namespace Questioner.Repository.Test.Tests
{
    public class ContextFactoryForSqliteTest
    {
        [Test]
        public void CreateDbContext_WhenCalled_Creates()
        {
            // Arrange
            const string expectedProviderName = "Microsoft.EntityFrameworkCore.Sqlite";

            var contextFactoryForSqlite = new ContextFactoryForSqlite();

            // Act
            var context = contextFactoryForSqlite.CreateDbContext(new string[] { });

            // Assert
            Assert.AreEqual(expectedProviderName, context.Database.ProviderName);
        }
    }
}