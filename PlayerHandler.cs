using Compass.API;
using Exiled.Events.EventArgs;
using PlayerEvents = Exiled.Events.Handlers.Player;

namespace Compass
{
    internal class PlayerHandler
    {
        public void SubscribeEvents() => PlayerEvents.Verified += OnPlayerVerified;

        public void UnSubscribeEvents() => PlayerEvents.Verified -= OnPlayerVerified;

        private void OnPlayerVerified(VerifiedEventArgs ev) => ev.Player.AddCompassDisplayComponent();
    }
}