﻿using Microsoft.Extensions.DependencyInjection;
using Moq;
using Questioner.WebApi.Extensions;
using Questioner.WebApi.Test.Framework.Mocks;

namespace Questioner.WebApi.Test.Tests
{
    internal class ServiceCollectionExtensionTest
    {
        private AppSettings appSettings;
        private Mock<IServiceCollection> serviceCollectionMock;
        private ConfigurationMock<AppSettings> configurationMock;

        [SetUp]
        public void SetUp()
        {
            appSettings = new AppSettings();
            serviceCollectionMock = new Mock<IServiceCollection>();

            serviceCollectionMock
                .Setup(s => s.GetEnumerator())
                .Returns(new[] { new ServiceDescriptor(typeof(string), string.Empty) }.ToList().GetEnumerator());

            configurationMock = new ConfigurationMock<AppSettings>(new ConfigurationSectionMock<AppSettings>(appSettings));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("mysql")]
        public void AddDbContext_WithNotSupportedDatabaseConnection_ThrowsNotSupportedException(string databaseConnector)
        {
            // Arrange
            var expectedExceptionMessage = $"The Database Connection '{databaseConnector}' is not supported.";
            appSettings.DatabaseConnector = databaseConnector;

            // Act
            void action() => serviceCollectionMock.Object.AddDbContext(configurationMock);

            // Assert
            Assert.That(action, Throws.TypeOf<NotSupportedException>().And.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        [TestCase("sqlite")]
        [TestCase("Sqlite")]
        [TestCase("SQLITE")]
        [TestCase("sqlServer")]
        [TestCase("sqlserver")]
        [TestCase("SQLSERVER")]
        [TestCase("SqlServer")]
        public void AddDbContext_WithSupportedDatabaseConnection_NoExceptionIsThrown(string databaseConnector)
        {
            // Arrange            
            appSettings.DatabaseConnector = databaseConnector;

            // Act
            void action() => serviceCollectionMock.Object.AddDbContext(configurationMock);

            // Assert
            Assert.That(action, Throws.Nothing);
        }
    }
}
