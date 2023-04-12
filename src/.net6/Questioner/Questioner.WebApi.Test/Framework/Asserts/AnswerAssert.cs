using Questioner.Repository.Entities;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.Test.Framework.Asserts
{
    public static class AnswerAssert
    {
        public static void Assert(List<Answer> expectedAnswers, List<Answer> actualAnswers)
        {
            That(actualAnswers?.Count, Is.EqualTo(expectedAnswers?.Count),
                message: $"The expected number of answers should be {expectedAnswers?.Count} and not {actualAnswers?.Count}.");

            foreach (var expectedAnswer in expectedAnswers)
            {
                var actualAnswer = actualAnswers.FirstOrDefault(a => a.AnswerText == expectedAnswer.AnswerText);

                NotNull(actualAnswer, message: $"The answer '{expectedAnswer.AnswerText}' should exist.");
                That(actualAnswer.IsCorrect, Is.EqualTo(expectedAnswer.IsCorrect),
                    message: $"The answer '{expectedAnswer.AnswerText}' should be {expectedAnswer.IsCorrect} and not {actualAnswer.IsCorrect}.");
            }
        }
    }
}
