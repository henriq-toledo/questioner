using Questioner.WebApi.Defaults;

namespace Questioner.WebApi.Test.Tests
{
    internal class AnswerModelDefaultTest
    {
        [Test]
        public void NoYes_WhenCalled_Retuns()
        {
            // Act
            var noYes = AnswerModelDefault.NoYes;

            // Assert
            Assert.That(noYes, Has.Length.EqualTo(2));

            var no = noYes[0];

            Assert.Multiple(() =>
            {
                Assert.That(no.IsCorrect, Is.False);
                Assert.That(no.AnswerText, Is.EqualTo("False"));
            });

            var yes = noYes[1];

            Assert.Multiple(() =>
            {
                Assert.That(yes.IsCorrect, Is.True);
                Assert.That(yes.AnswerText, Is.EqualTo("True"));
            });
        }
    }
}
