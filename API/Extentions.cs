using System;
using Compass.API.Features;
using Exiled.API.Features;

namespace Compass.API
{
    internal static class Extentions
    {
        public static CompassDisplayComponent AddCompassDisplayComponent(this Player player)
        {
            if (player.GameObject.GetComponent<CompassDisplayComponent>() != null)
            {
                throw new InvalidOperationException($"'{nameof(CompassDisplayComponent)}' is already attached to player");
            }

            return player.GameObject.AddComponent<CompassDisplayComponent>();
        }

        public static void RemoveCompassDisplayComponent(this Player player)
        {
            var compassDisplayComponent = player.GameObject.GetComponent<CompassDisplayComponent>();

            if (compassDisplayComponent == null)
            {
                throw new NullReferenceException($"'{nameof(CompassDisplayComponent)}' is not attached to player");
            }

            compassDisplayComponent.DestroySelf();
        }
    }
}