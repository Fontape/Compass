using Compass.API;
using static NUnit.Framework.Assert;

namespace CompassUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsDegreesOverflowHandleCorrectly()
        {
            int handledDegrees = 489495495.GetOverflowedDegrees();

            IsTrue(IsHandledDegreesValid(handledDegrees), $"{handledDegrees}");
        }

        [Test]
        public void IsDegreesNegativeOverflowHandleCorrectly()
        {
            int handledDegrees = (-93939393).GetOverflowedDegrees();

            IsTrue(IsHandledDegreesValid(handledDegrees), $"{handledDegrees}");
        }

        [Test]
        public void IsDegreesNonOverflowHandleCorrectly()
        {
            int handledDegrees = 360.GetOverflowedDegrees();

            IsTrue(IsHandledDegreesValid(handledDegrees), $"{handledDegrees}");
        }

        private static bool IsHandledDegreesValid(int handledDegrees) =>
            handledDegrees is >= 0 and <= 360;
    }
}