using Questioner.WebApi.Services;
using Questioner.WebApi.Test.Framework.Factories;

namespace Questioner.WebApi.Test.Tests
{
    internal class ContextForSqliteServiceTest
    {
        [Test]
        public void GetContext_WhenCalled_ReturnsContext()
        {
            // Arrange
            using var context = ContextFactory.CreateContextForSqlite();
            var contextForSqliteService = new ContextForSqliteService(context);

            // Act
            var actualContext = contextForSqliteService.GetContext();

            // Assert
            Assert.AreSame(context, actualContext);
        }
    }
}
