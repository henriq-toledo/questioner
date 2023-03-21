using NUnit.Framework;
using Questioner.WebApi.Defaults;

namespace Questioner.WebApi.Test.Tests
{
    internal class AnswerDefaultTest
    {
        [Test]
        public void NoYes_WhenCalled_Retuns()
        {
            // Act
            var noYes = AnswerDefault.NoYes;

            // Assert
            Assert.That(noYes.Length, Is.EqualTo(2));

            var no = noYes[0];

            Assert.That(no.IsCorrect, Is.False);
            Assert.That(no.AnswerText, Is.EqualTo("False"));

            var yes = noYes[1];

            Assert.That(yes.IsCorrect, Is.True);
            Assert.That(yes.AnswerText, Is.EqualTo("True"));
        }
    }
}
