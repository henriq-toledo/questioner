using System;

namespace Questioner.Web.Enums
{
    public enum QuestionResultEnum
    {
        Incorrect,
        Correct,
        NotAnswered
    }

    public static class QuestionResultEnumExtension
    {
        public static string GetDescription(this QuestionResultEnum questionResult)
        {
            switch (questionResult)
            {
                case QuestionResultEnum.Correct: return "Yes";
                case QuestionResultEnum.Incorrect: return "No";
                case QuestionResultEnum.NotAnswered: return "Not answered";
                default: throw new NotImplementedException();
            }
        }
    }
}