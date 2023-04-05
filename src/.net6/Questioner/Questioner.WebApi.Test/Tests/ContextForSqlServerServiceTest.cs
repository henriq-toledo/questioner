using NUnit.Framework;
using Questioner.WebApi.Services;
using Questioner.WebApi.Test.Framework.Factories;

namespace Questioner.WebApi.Test.Tests
{
    internal class ContextForSqlServerServiceTest
    {
        [Test]
        public void GetContext_WhenCalled_ReturnsContext()
        {
            // Arrange
            using var context = ContextFactory.CreateContextForSqlServer();
            var contextForSqlServerService = new ContextForSqlServerService(context);

            // Act
            var actualContext = contextForSqlServerService.GetContext();

            // Assert
            Assert.AreSame(context, actualContext);
        }
    }
}
