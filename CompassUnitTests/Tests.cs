using Compass;
using Compass.API;
using static NUnit.Framework.Assert;

namespace CompassUnitTests
{
    public class Tests
    {
        [Test]
        public void IsDegreesOverflowHandleCorrectly()
        {
            int handledDegrees = 489495495.GetOverflowedDegrees();

            That(IsHandledDegreesValid(handledDegrees), Is.True, $"{handledDegrees}");
        }

        [Test]
        public void IsDegreesNegativeOverflowHandleCorrectly()
        {
            int handledDegrees = (-93939393).GetOverflowedDegrees();

            That(IsHandledDegreesValid(handledDegrees), Is.True, $"{handledDegrees}");
        }

        [Test]
        public void IsDegreesNonOverflowHandleCorrectly()
        {
            int handledDegrees = 360.GetOverflowedDegrees();

            That(IsHandledDegreesValid(handledDegrees), Is.True, $"{handledDegrees}");
        }

        [Test]
        public void IsWorldSideHandleValidValues()
        {
            WorldSidesTranslations translations = new ();

            for (var i = 0; i <= 360; i++)
            {
                DoesNotThrow(() => i.GetWorldSide(translations), $"{i}");
            }
        }

        [Test]
        public void IsWorldSideHandleInvalidValues()
        {
            const int InvalidValue = 361;

            WorldSidesTranslations translations = new ();
            Throws<InvalidOperationException>(() => InvalidValue.GetWorldSide(translations), $"{InvalidValue}");
        }

        private static bool IsHandledDegreesValid(int handledDegrees) =>
            handledDegrees is >= 0 and <= 360;
    }
}