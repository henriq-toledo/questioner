﻿using Questioner.WebApp.Enums;

namespace Questioner.WebApp.Test.Tests
{
    internal class QuestionResultExtensionTest
    {
        [Test]
        [TestCase(QuestionResult.Correct, "Yes")]
        [TestCase(QuestionResult.Incorrect, "No")]
        [TestCase(QuestionResult.NotAnswered, "Not answered")]
        public void GetDescription_WhenCalled_ReturnsDescription(QuestionResult questionResult, string expectedDescription)
        {
            // Act
            var actualDescription = questionResult.GetDescription();

            // Assert
            Assert.That(actualDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void GetDescription_WithInvalidValue_ThrowsNotImplementedException(QuestionResult questionResult)
        {
            // Arrange
            var expectedExceptionMessage = $"The {questionResult} question result was not implemented";

            // Act
            void action() => questionResult.GetDescription();

            // Assert
            Assert.That(action, Throws.TypeOf<NotImplementedException>().And.Message.EqualTo(expectedExceptionMessage));
        }
    }
}
