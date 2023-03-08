using Questioner.Repository.Entities;

namespace Questioner.WebApi.Defaults
{
    internal static class AnswerDefault
    {
        private static Answer No => new Answer()
        {
            AnswerText = "False"
        };

        private static Answer Yes => new Answer()
        {
            AnswerText = "True",
            IsCorrect = true
        };

        public static Answer[] NoYes => new Answer[] { No, Yes };
    }
}