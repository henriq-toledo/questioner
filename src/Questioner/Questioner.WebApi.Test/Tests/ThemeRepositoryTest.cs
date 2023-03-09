using Moq;
using NUnit.Framework;
using Questioner.Repository.Contexts;
using Questioner.Repository.Entities;
using Questioner.WebApi.Repositories;
using Questioner.WebApi.Services;
using Questioner.WebApi.Test.Framework.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.WebApi.Test.Tests
{
    internal class ThemeRepositoryTest
    {
        private Context context;
        private ThemeRepository themeRepository;
        private Mock<IContextService> contextServiceMock;

        [SetUp]
        public void SetUp()
        {
            contextServiceMock = new Mock<IContextService>();
            context = ContextFactory.CreateContextForSqlServer();

            contextServiceMock.Setup(m => m.GetContext()).Returns(context);

            themeRepository = new ThemeRepository(contextServiceMock.Object);
        }

        [Test]
        public async Task Create_WhenCalled_Creates()
        {
            // Arrange
            var theme = new Theme();

            // Act
            await themeRepository.Create(theme);

            // Assert
            var actualTheme = context.Themes.FirstOrDefault();

            Assert.AreSame(theme, actualTheme);
        }

        [Test]
        public async Task Delete_WhenCalled_Deletes()
        {
            // Arrange
            const int themeId = 1;
            var theme = new Theme { Id = themeId };

            await context.Themes.AddAsync(theme);
            await context.SaveChangesAsync();

            // Act
            await themeRepository.Delete(themeId);

            // Assert
            var exists = context.Themes.Any();

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task ExistsTheme_WhenExists_ReturnsTrue()
        {
            // Arrange
            const int themeId = 1;
            var theme = new Theme { Id = themeId };

            await context.Themes.AddAsync(theme);
            await context.SaveChangesAsync();

            // Act
            var exists = await themeRepository.ExistsTheme(themeId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsTheme_WhenNoExists_ReturnsFalse()
        {
            // Arrange
            const int themeId = 1;

            // Act
            var exists = await themeRepository.ExistsTheme(themeId);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAll_WithIncludeChildren_ReturnsThemesIncludingChildren()
        {
            // Arrange            
            var theme1 = new Theme
            {                
                Topics = new List<Topic>
                {
                    new Topic
                    {
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Answers = new List<Answer>
                                {
                                    new Answer()
                                }
                            }
                        }
                    }
                }
            };
            var theme2 = new Theme
            {                
                Topics = new List<Topic>
                {
                    new Topic
                    {
                        Questions = new List<Question>
                        {
                            new Question
                            {
                                Answers = new List<Answer>
                                {
                                    new Answer()
                                }
                            }
                        }
                    }
                }
            };

            await context.Themes.AddAsync(theme1);
            await context.Themes.AddAsync(theme2);
            await context.SaveChangesAsync();

            // Act
            var themes = await themeRepository.GetAll(includeChildren: true);

            // Assert
            CollectionAssert.Contains(themes, theme1);
            CollectionAssert.Contains(themes, theme2);
        }
    }
}
