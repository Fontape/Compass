using System;
using System.Text;
using Compass.API.Enums;
using Exiled.API.Features;
using Mirror;
using UnityEngine;

namespace Compass.API.Features
{
    internal class CompassDisplayComponent : NetworkBehaviour
    {
        private Player _compassViewer;
        private float _secondsToNextTick;

        public void Awake() => _compassViewer = Player.Get(gameObject);

        public void FixedUpdate()
        {
            if (IsCompassEnabled() == false)
            {
                return;
            }

            if (_secondsToNextTick < 0.1f)
            {
                _secondsToNextTick += Time.deltaTime;
                return;
            }

            var viewerRotation = (int)_compassViewer.Rotation.y;
            _secondsToNextTick = 0;

            _compassViewer.Broadcast(1,
                $"{DrawCompassLine(viewerRotation)}",
                Broadcast.BroadcastFlags.Monospaced,
                true);
        }

        public void DestroySelf() => Destroy(this);

        private static string DrawCompassLine(int degrees)
        {
            int leftDegrees = GetOverflowedDegrees(degrees - 45);
            int rightDegrees = GetOverflowedDegrees(degrees + 45);

            var lineBuilder = new StringBuilder();

            for (var i = 0; i < 60; i++)
            {
                lineBuilder.Append("|");
            }

            var longSpaceBuilder = new string(' ', 10);

            return $"<b><size=24>{GetCardinalDirection(degrees)}" +
                   $"\n{lineBuilder}</size></b>" +
                   $"\n<size=32><color=#ccc>{leftDegrees}°</color></size>{longSpaceBuilder}<b>{degrees}°</b>{longSpaceBuilder}<size=32><color=#ccc>{rightDegrees}°</color></size>";
        }

        public static int GetOverflowedDegrees(int degrees) => degrees switch
        {
            < 0 => 360 - degrees,
            > 360 => degrees - 360,
            _ => degrees
        };

        private static string GetCardinalDirection(int degrees) => degrees switch
        {
            >= 0 and <= 90 => "СЕВЕР",
            > 90 and <= 180 => "ВОСТОК",
            > 180 and <= 270 => "ЮГ",
            > 270 and <= 360 => "ЗАПАД",
            _ => throw new InvalidOperationException()
        };

        private bool IsCompassEnabled()
        {
            switch (CompassPlugin.CompassVisibilityMode)
            {
                case CompassVisibilityMode.FirearmHolders when _compassViewer.CurrentItem == null || _compassViewer.CurrentItem.IsWeapon == false:
                case CompassVisibilityMode.SquadMembers when _compassViewer.Role.Team != Team.MTF && _compassViewer.Role.Team != Team.CHI:
                    return false;

                case CompassVisibilityMode.Humans:
                default:
                    return _compassViewer.IsHuman;
            }
        }
    }
}