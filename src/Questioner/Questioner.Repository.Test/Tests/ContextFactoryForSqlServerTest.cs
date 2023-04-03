using NUnit.Framework;
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

            var contextFactoryForSqlServer = new ContextFactoryForSqlServer();

            // Act
            var context = contextFactoryForSqlServer.CreateDbContext(new string[] { });

            // Assert
            Assert.AreEqual(expectedProviderName, context.Database.ProviderName);
        }
    }
}
