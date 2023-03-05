﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Questioner.Repository.Classes.Entities;
using Questioner.Web.Controllers;
using Questioner.Web.Models;
using Questioner.Web.Services;
using Questioner.Web.Test.Framework.Asserts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questioner.Web.Test.Tests
{
    internal class HomeControllerTest
    {
        private HomeController homeController;
        private Mock<IThemeService> themeServiceMock;

        [SetUp]
        public void SetUp()
        {
            themeServiceMock = new Mock<IThemeService>();

            homeController = new HomeController(themeServiceMock.Object);
        }

        [Test]
        public async Task Index_WhenCalled_ReturnsThemes()
        {
            // Arrange
            const int themeId = 1;
            const byte passRate = 80;
            const string themeName = "Test";
            var themes = new Theme[]
            {
                new Theme
                {
                    Id = themeId,
                    Name = themeName,
                    PassRate = passRate,
                    Topics = new List<Topic>
                    {
                        new Topic 
                        {
                            Questions = new List<Question>
                            { 
                                new Question(),
                                new Question()
                            }
                        }
                    }
                }
            };
            var expectedThemeListViewModels = new List<ThemeListViewModel>
            { 
                new ThemeListViewModel
                {
                    Id = themeId,
                    Name = themeName,
                    PassRate = passRate,
                    TopicsQuantity = 1,
                    QuestionsQuantity = 2
                }
            };
            themeServiceMock.Setup(m => m.GetAllThemes()).ReturnsAsync(themes);

            // Act
            var actionResult = (ViewResult)await homeController.Index();

            // Assert
            themeServiceMock.Verify(m => m.GetAllThemes(), Times.Once);
            Assert.IsInstanceOf<List<ThemeListViewModel>>(actionResult.Model);
            ThemeListViewModelAssert.AreEqual(expectedThemeListViewModels, (List<ThemeListViewModel>)actionResult.Model);
        }
    }
}