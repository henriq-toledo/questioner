using Questioner.Repository.Contexts;

namespace Questioner.Repository.Test.Tests
{
    internal class ContextFactoryForSqlServerTest
    {
        [Test]
        public void CreateDbContext_WhenCalled_Creates()
        {
            // Arrange
            const string expectedProviderName = "Microsoft.EntityFrameworkCore.SqlServer";

            ContextFactoryForSqlServer contextFactoryForSqlServer = new();

            // Act
            var context = contextFactoryForSqlServer.CreateDbContext(Array.Empty<string>());

            // Assert
            Assert.That(context.Database.ProviderName, Is.EqualTo(expectedProviderName));
        }
    }
}
