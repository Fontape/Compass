﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compass.API.Enums;
using Compass.API.Features;
using Exiled.API.Features;

namespace Compass.API
{
    internal static class Extentions
    {
        public static CompassDisplayComponent AddCompassDisplayComponent(this Player player) =>
            player.GameObject.AddComponent<CompassDisplayComponent>();

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
