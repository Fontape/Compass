using Compass.API;
using Compass.API.Features;
using Compass.API.Interfaces;
using Exiled.Events.EventArgs;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace Compass
{
    internal class PlayerHandler
    {
        private readonly IReadOnlyWorldSidesTranslations _worldSidesTranslations;

        public PlayerHandler(IReadOnlyWorldSidesTranslations worldSidesTranslations) =>
            _worldSidesTranslations = worldSidesTranslations;

        public void SubscribeEvents() => PlayerEvents.Verified += OnPlayerVerified;

        public void UnSubscribeEvents() => PlayerEvents.Verified -= OnPlayerVerified;

        private void OnPlayerVerified(VerifiedEventArgs ev)
        {
            CompassDisplayComponent compassDisplayComponent = ev.Player.AddCompassDisplayComponent();
            compassDisplayComponent.SetupTranslations(_worldSidesTranslations);
        }
    }
}