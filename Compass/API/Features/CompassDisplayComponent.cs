using Compass.API.Enums;
using Compass.API.Interfaces;
using Exiled.API.Features;
using Mirror;
using UnityEngine;

namespace Compass.API.Features
{
    internal class CompassDisplayComponent : NetworkBehaviour
    {
        private const int DegreesFromBroadcastMiddle = 20;
        private const float DegreesBroadcastUpdateRate = 0.1f;

        private Player _compassViewer;
        private float _secondsToNextCompassBroadcast;
        private IReadOnlyWorldSidesTranslations _worldSidesTranslations;

        public void Awake() => _compassViewer = Player.Get(gameObject);

        public void SetupTranslations(IReadOnlyWorldSidesTranslations worldSidesTranslations) =>
            _worldSidesTranslations = worldSidesTranslations;

        public void FixedUpdate()
        {
            if (IsCompassEnabled() == false)
            {
                return;
            }

            if (_secondsToNextCompassBroadcast < DegreesBroadcastUpdateRate)
            {
                _secondsToNextCompassBroadcast += Time.deltaTime;
                return;
            }

            _secondsToNextCompassBroadcast = 0;
            var viewerRotation = (int)_compassViewer.Rotation.y;

            _compassViewer.Broadcast(1,
                $"{GetCompassBroadcastText(viewerRotation)}",
                Broadcast.BroadcastFlags.Monospaced,
                true);
        }

        private string GetCompassBroadcastText(int viewerRotation)
        {
            int leftDegrees = (viewerRotation - DegreesFromBroadcastMiddle).GetOverflowedDegrees();
            int rightDegrees = (viewerRotation + DegreesFromBroadcastMiddle).GetOverflowedDegrees();

            var compassLine = new string('|', 60);
            var longSpaceString = new string(' ', 10);

            return $"<b><size=24>{viewerRotation.GetWorldSide(_worldSidesTranslations)}" +
                   $"\n{compassLine}</size></b>" +
                   $"\n<size=32><color=#ccc>{leftDegrees}°</color></size>{longSpaceString}<b>{viewerRotation}°</b>{longSpaceString}<size=32><color=#ccc>{rightDegrees}°</color></size>";
        }

        private bool IsCompassEnabled()
        {
            if (_worldSidesTranslations == null)
            {
                return false;
            }

            switch (CompassPlugin.CompassVisibilityMode)
            {
                case CompassVisibilityMode.FirearmHolders
                    when _compassViewer.CurrentItem == null || _compassViewer.CurrentItem.IsWeapon == false:
                case CompassVisibilityMode.SquadMembers
                    when _compassViewer.Role.Team != Team.MTF && _compassViewer.Role.Team != Team.CHI:
                    return false;

                case CompassVisibilityMode.Humans:
                default:
                    return _compassViewer.IsHuman;
            }
        }
    }
}