using System;
using Compass.API.Features;
using Compass.API.Interfaces;
using Exiled.API.Features;

namespace Compass.API
{
    public static class Extensions
    {
        public static int GetOverflowedDegrees(this int degrees) => degrees switch
        {
            < 0 => degrees % 360 + 360,
            > 360 => degrees % 360,
            _ => degrees
        };

        public static string GetWorldSide(this int degrees, IReadOnlyWorldSidesTranslations translations) => degrees switch
        {
            >= 0 and <= 90 => translations.North,
            > 90 and <= 180 => translations.East,
            > 180 and <= 270 => translations.South,
            > 270 and <= 360 => translations.West,
            _ => throw new InvalidOperationException()
        };

        internal static CompassDisplayComponent AddCompassDisplayComponent(this Player player)
        {
            if (player.GameObject.GetComponent<CompassDisplayComponent>() != null)
            {
                throw new InvalidOperationException($"'{nameof(CompassDisplayComponent)}' is already attached to player");
            }

            return player.GameObject.AddComponent<CompassDisplayComponent>();
        }
    }
}