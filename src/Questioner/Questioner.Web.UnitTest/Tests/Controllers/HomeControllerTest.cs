using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Questioner.Repository.Classes.Entities;
using Questioner.Web.Controllers;
using Questioner.Web.Models;
using Questioner.Web.Services;
using Questioner.Web.UnitTest.Framework.Asserts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questioner.Web.UnitTest.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public async Task IndexShouldReturnAllThemes()
        {
            Theme[] themes = new Theme[]
            {
                new Theme
                {
                    Id = 1,
                    Name = "Test 1",
                    PassRate = 60,
                    Topics = new List<Topic>
                    {
                        new Topic
                        {
                            Questions = new List<Question>
                            {
                                new Question(),
                                new Question()
                            }
                        },
                        new Topic
                        {
                            Questions = new List<Question>
                            {
                                new Question(),
                                new Question(),
                                new Question()
                            }
                        },
                    }
                }
            };

            // Arrange
            var themeServiceMock = new Mock<IThemeService>();
            themeServiceMock.Setup(t => t.GetAllThemes()).ReturnsAsync(themes);

            var homeController = new HomeController(themeServiceMock.Object);

            // Act
            var result = (await homeController.Index()) as ViewResult;

            // Assert
            Assert.IsInstanceOf<List<ThemeListViewModel>>(result.Model, message: "");

            var actualThemeListViewModel = result.Model as List<ThemeListViewModel>;

            ThemeListViewModelAssert.Assert(expectedThemeListViewModel: themes.Select(theme => new ThemeListViewModel(theme)).ToList(), actualThemeListViewModel);
        }
    }
}
