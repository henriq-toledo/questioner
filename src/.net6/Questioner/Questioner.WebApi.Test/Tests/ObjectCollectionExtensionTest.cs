using Questioner.WebApi.Extensions;

namespace Questioner.WebApi.Test.Tests
{
    internal class ObjectCollectionExtensionTest
    {
        [Test]
        [TestCase(null, true)]
        [TestCase(new int[] { }, true)]
        [TestCase(new int[] { 0 }, false)]
        public void IsNullOrEmpty_WhenCalled_Returns(int[] collection, bool expectedResult)
        {
            // Act
            var actualResult = collection.IsNullOrEmpty();

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
