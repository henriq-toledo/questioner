using Questioner.Repository.Entities;
using static NUnit.Framework.Assert;

namespace Questioner.WebApi.Test.Framework.Asserts
{
    public static class TopicAssert
    {
        public static void Assert(List<Topic> expectedTopics, List<Topic> actualTopics)
        {
            That(actualTopics?.Count, Is.EqualTo(expectedTopics?.Count),
                message: $"The expected number of topics should be {expectedTopics?.Count} and not {actualTopics?.Count}.");

            foreach (var expectedTopic in expectedTopics)
            {
                var actualTopic = actualTopics.FirstOrDefault(t => t.Name == expectedTopic.Name);

                That(actualTopic, Is.Not.Null, message: $"The topic '{expectedTopic.Name}' should exist.");

                That(actualTopic.Percentage, Is.EqualTo(expectedTopic.Percentage), 
                    message: $"The expected topic's percentage from '{expectedTopic.Name}' topic should be {expectedTopic.Percentage} and not {actualTopic.Percentage}.");

                QuestionAssert.Assert(expectedQuestions: expectedTopic?.Questions, actualQuestions: actualTopic?.Questions);
            }
        }
    }
}
