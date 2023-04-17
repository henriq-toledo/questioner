using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Moq;

namespace Questioner.WebApi.Test.Framework.Mocks
{
    internal class ConfigurationSectionMock<T> : IConfigurationSection
    {
        private readonly T sectionValue;

        public string this[string key] { get => Value; set => Value = value; }

        public string Key { get; }

        public string Path { get; }

        public string Value { get; set; }

        public ConfigurationSectionMock(T sectionValue)
        {
            this.sectionValue = sectionValue;
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
            var value = typeof(T).GetProperty(key).GetValue(this.sectionValue)?.ToString();

            var configurationSectionMock = new Mock<IConfigurationSection>();

            configurationSectionMock.Setup(m => m.Value).Returns(value);


            return configurationSectionMock.Object;
        }
    }
}
