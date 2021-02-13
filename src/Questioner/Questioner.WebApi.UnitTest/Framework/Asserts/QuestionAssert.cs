using Questioner.Repository.Classes.Entities;
using System.Collections.Generic;
using System.Linq;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.UnitTest.Framework.Asserts
{
    public static class QuestionAssert
    {
        public static void Assert(List<Question> expectedQuestions, List<Question> actualQuestions)
        {
            AreEqual(expectedQuestions?.Count, actualQuestions?.Count, 
                message: $"The expected number of questions should be {expectedQuestions?.Count} and not {actualQuestions?.Count}.");

            foreach (var expectedQuestion in expectedQuestions)
            {
                var actualQuestion = actualQuestions.FirstOrDefault(q => q.QuestionText == expectedQuestion.QuestionText);

                NotNull(actualQuestion, message: $"The question '{expectedQuestion.QuestionText}' should exist.");

                AnswerAssert.Assert(expectedAnswers: expectedQuestion?.Answers, actualAnswers: actualQuestion?.Answers);
            }
        }
    }
}
