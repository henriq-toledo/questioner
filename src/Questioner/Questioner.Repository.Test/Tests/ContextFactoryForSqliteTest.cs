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

            ContextFactoryForSqlite contextFactoryForSqlite = new();

            // Act
            var context = contextFactoryForSqlite.CreateDbContext(Array.Empty<string>());

            // Assert
            Assert.That(context.Database.ProviderName, Is.EqualTo(expectedProviderName));
        }
    }
}