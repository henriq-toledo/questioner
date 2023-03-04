using Questioner.Repository.Classes.Entities;
using Questioner.WebApi.Models;
using Questioner.WebApi.Test.Framework.Defaults;

namespace Questioner.WebApi.Test.TestCases
{
    public class ThemeModelValidatorTestCase
    {
        public static ThemeModel[] QuestionShouldHaveAtLeastTwoAnswersTestCase => new[]
        {
            ThemeModelDefault.ThemeWithQuestionWithNullAnswers,
            ThemeModelDefault.ThemeWithQuestionWithEmptyAnswers,
            ThemeModelDefault.ThemeWithQuestionWithOnlyOneAnswer
        };

        public static ThemeModel[] TopicWithoutQuestionsShouldBeInvalidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithTopicWithNullQuestions,
            ThemeModelDefault.ThemeWithTopicWithEmptyQuestions
        };

        public static ThemeModel[] SumFromTopicsPercentageDifferentFromOneHundredShouldBeInvalidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithTopicsPercentageMoreThanOneHundred,
            ThemeModelDefault.ThemeWithTopicsPercentageLessThanOneHundred
        };

        public static ThemeModel[] SumFromTopicsPercentageEqualOneHundredShouldBeValidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithTopicsPercentageOneHundred
        };

        public static ThemeModel[] ThemeWithoutTopicsShouldBeInvalidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithNullTopics,
            ThemeModelDefault.ThemeWithEmptyTopics
        };

        public static ThemeModel[] ThemeWithoutNameShouldBeInvalidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithNullName,
            ThemeModelDefault.ThemeWithEmptyName,
        };

        public static (Theme, ThemeModel)[] DuplicatedThemeNameShouldBeInvalidTestCase => new[]
        {
            (ThemeDefault.ThemeWithDefaultName, ThemeModelDefault.ThemeWithDefaultName)
        };

        public static ThemeModel[] QuestionWithoutCorrectAnswerShouldBeInvalidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithQuestionWithoutCorrectAnswer
        };

        public static ThemeModel[] ThemeWithPassRateOutsideRangeShouldBeInvalidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithPassRateLessThanMin,
            ThemeModelDefault.ThemeWithPassRateMoreThanMax
        };

        public static ThemeModel[] ThemeWithPassRateInsideRangeShouldBeValidTestCase => new[]
        {
            ThemeModelDefault.ThemeWithMinValidPassRate,
            ThemeModelDefault.ThemeWithMaxValidPassRate,
            ThemeModelDefault.ThemeWithChildren
        };
    }
}
