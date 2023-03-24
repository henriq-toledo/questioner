using Questioner.WebApi.Models;

namespace Questioner.WebApi.Defaults
{
    internal static class AnswerModelDefault
    {
        private static AnswerModel No => new AnswerModel()
        {
            AnswerText = "False"
        };

        private static AnswerModel Yes => new AnswerModel()
        {
            AnswerText = "True",
            IsCorrect = true
        };

        public static AnswerModel[] NoYes => new AnswerModel[] { No, Yes };
    }
}