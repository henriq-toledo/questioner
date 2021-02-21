﻿using Questioner.WebApi.Models;
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
    }
}
