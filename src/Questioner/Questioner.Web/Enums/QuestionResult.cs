using System;

namespace Questioner.Web.Enums
{
    public enum QuestionResult
    {
        Incorrect,
        Correct,
        NotAnswered
    }

    public static class QuestionResultExtension
    {
        public static string GetDescription(this QuestionResult questionResult) => questionResult switch
        {
            QuestionResult.Correct => "Yes",
            QuestionResult.Incorrect => "No",
            QuestionResult.NotAnswered => "Not answered",
            _ => throw new NotImplementedException($"The {questionResult} question result was not implemented"),
        };
    }
}