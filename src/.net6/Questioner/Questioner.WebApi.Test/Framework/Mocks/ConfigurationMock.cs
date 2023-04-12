using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Questioner.WebApi.Test.Framework.Mocks
{
    internal class ConfigurationMock<T> : IConfiguration
    {        
        private readonly ConfigurationSectionMock<T> configurationSectionMock;

        private string value;

        public string this[string key] { get => value; set => this.value = value; }

        public ConfigurationMock(ConfigurationSectionMock<T> configurationSectionMock)
        {            
            this.configurationSectionMock = configurationSectionMock;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            var configurationSectionMock = new Mock<IConfigurationSection>();

            return new IConfigurationSection[] { configurationSectionMock.Object };
        }

        public IChangeToken GetReloadToken()
        {
            return null;
        }

        public IConfigurationSection GetSection(string key)
        {
            if (key == typeof(T).Name)
            {
                return configurationSectionMock;
            }

            return null;
        }
    }
}
