using Questioner.Repository.Classes.Entities;
using System.Collections.Generic;
using System.Linq;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.UnitTests.Framework.Asserts
{
    public static class AnswerAssert
    {
        public static void Assert(List<Answer> expectedAnswers, List<Answer> actualAnswers)
        {
            AreEqual(expectedAnswers?.Count, actualAnswers?.Count,
                message: $"The expected number of answers should be {expectedAnswers?.Count} and not {actualAnswers?.Count}.");

            foreach (var expectedAnswer in expectedAnswers)
            {
                var actualAnswer = actualAnswers.FirstOrDefault(a => a.AnswerText == expectedAnswer.AnswerText);

                NotNull(actualAnswer, message: $"The answer '{expectedAnswer.AnswerText}' should exist.");

                AreEqual(expectedAnswer.IsCorrect, actualAnswer.IsCorrect,
                    message: $"The answer '{expectedAnswer.AnswerText}' should be {expectedAnswer.IsCorrect} and not {actualAnswer.IsCorrect}.");
            }
        }
    }
}
