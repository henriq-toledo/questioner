using Questioner.WebApi.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Questioner.WebApi.Test")]

namespace Questioner.WebApi.Defaults
{
    internal static class AnswerModelDefault
    {
        private static AnswerModel No => new()
        {
            AnswerText = "False"
        };

        private static AnswerModel Yes => new()
        {
            AnswerText = "True",
            IsCorrect = true
        };

        public static AnswerModel[] NoYes => new[] { No, Yes };
    }
}