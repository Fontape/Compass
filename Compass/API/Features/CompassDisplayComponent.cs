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

        private static string DrawCompassLine(int degrees)
        {
            int leftDegrees = (degrees - 45).GetOverflowedDegrees();
            int rightDegrees = (degrees + 45).GetOverflowedDegrees();

            var lineBuilder = new StringBuilder();

            for (var i = 0; i < 60; i++)
            {
                lineBuilder.Append("|");
            }

            var longSpaceBuilder = new string(' ', 10);

            return $"<b><size=24>{degrees.GetCardinalDirection()}" +
                   $"\n{lineBuilder}</size></b>" +
                   $"\n<size=32><color=#ccc>{leftDegrees}°</color></size>{longSpaceBuilder}<b>{degrees}°</b>{longSpaceBuilder}<size=32><color=#ccc>{rightDegrees}°</color></size>";
        }

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