using System.Collections;

namespace Questioner.WebApp.Test.Framework.Asserts
{
    internal static class ObjectAssert
    {
        public static void AreEqual(object expected, object actual)
        {
            var type = expected.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var actualPropertyValue = property.GetValue(actual);
                var expectedPropertyValue = property.GetValue(expected);

                if (property.PropertyType.IsArray || property.PropertyType.Namespace == "System.Collections.Generic")
                {
                    AreCollectionsEqual((IEnumerable)expectedPropertyValue, (IEnumerable)actualPropertyValue);
                }
                else
                {
                    Assert.That(actualPropertyValue, Is.EqualTo(expectedPropertyValue),
                        message: $"The {property.Name} property of the {type.Name} class should be {expectedPropertyValue} and not {actualPropertyValue}.");
                }
            }
        }

        public static void AreCollectionsEqual(IEnumerable expected, IEnumerable actual, string propertyName = null)
        {
            if (expected == null)
            {
                var message = propertyName == null ?
                    "The value should be null." : $"The value of the {propertyName} property should be null.";

                Assert.IsNull(actual, message);
            }
            else
            {
                var actualArray = actual.Cast<object>().ToArray();
                var expectedArray = expected.Cast<object>().ToArray();

                Assert.That(actualArray.Length, Is.EqualTo(expectedArray.Length),
                    message: $"The {expected.GetType().Name} collection length should be {expectedArray.Length} and not {actualArray.Length}.");

                for (int i = 0; i < expectedArray.Length; i++)
                {
                    var actualTheme = actualArray[i];
                    var expectedTheme = expectedArray[i];

                    AreEqual(expectedTheme, actualTheme);
                }
            }
        }
    }
}
