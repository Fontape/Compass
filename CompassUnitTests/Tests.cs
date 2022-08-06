using Compass.API;

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
            Assert.LessOrEqual(400.GetOverflowedDegrees(), 360);
        }

        [Test]
        public void IsDegreesNegativeOverflowHandleCorrectly()
        {
            Assert.LessOrEqual((-200).GetOverflowedDegrees(), 360);
        }

        [Test]
        public void IsDegreesNegativeOverflowHandleCorrectly()
        {
            Assert.LessOrEqual((-200).GetOverflowedDegrees(), 360);
        }
    }
}