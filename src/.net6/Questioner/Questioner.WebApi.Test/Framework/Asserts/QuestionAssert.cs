using Questioner.Repository.Entities;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.Test.Framework.Asserts
{
    public static class QuestionAssert
    {
        public static void Assert(List<Question> expectedQuestions, List<Question> actualQuestions)
        {
            That(actualQuestions?.Count, Is.EqualTo(expectedQuestions?.Count), 
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
