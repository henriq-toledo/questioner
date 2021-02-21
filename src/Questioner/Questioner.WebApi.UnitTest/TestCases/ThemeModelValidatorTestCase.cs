using Questioner.WebApi.Models;
using Questioner.WebApi.UnitTest.Framework.Defaults;

namespace Questioner.WebApi.UnitTest.TestCases
{
    public class ThemeModelValidatorTestCase
    {
        public static ThemeModel[] QuestionShouldHaveAtLeastTwoAnswersTestCase => new[]
        {
            ThemeModelDefault.ThemeWithQuestionWithNullAnswers,
            ThemeModelDefault.ThemeWithQuestionWithEmptyAnswers,
            ThemeModelDefault.ThemeWithQuestionWithOnlyOneAnswer
        };
    }
}
