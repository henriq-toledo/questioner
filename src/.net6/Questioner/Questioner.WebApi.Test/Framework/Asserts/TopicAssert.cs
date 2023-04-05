using Questioner.Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.Test.Framework.Asserts
{
    public static class TopicAssert
    {
        public static void Assert(List<Topic> expectedTopics, List<Topic> actualTopics)
        {
            AreEqual(expectedTopics?.Count, actualTopics?.Count,
                message: $"The expected number of topics should be {expectedTopics?.Count} and not {actualTopics?.Count}.");

            foreach (var expectedTopic in expectedTopics)
            {
                var actualTopic = actualTopics.FirstOrDefault(t => t.Name == expectedTopic.Name);

                NotNull(actualTopic, message: $"The topic '{expectedTopic.Name}' should exist.");

                AreEqual(expectedTopic.Percentage, actualTopic.Percentage, 
                    message: $"The expected topic's percentage from '{expectedTopic.Name}' topic should be {expectedTopic.Percentage} and not {actualTopic.Percentage}.");

                QuestionAssert.Assert(expectedQuestions: expectedTopic?.Questions, actualQuestions: actualTopic?.Questions);
            }
        }
    }
}
