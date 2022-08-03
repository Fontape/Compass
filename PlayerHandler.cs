using Compass.API;
using Compass.API.Enums;
using PlayerEvents = Exiled.Events.Handlers.Player;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace Compass
{
    internal class PlayerHandler
    {
        public void SubscribeEvents()
        {
            PlayerEvents.Verified += OnPlayerVerified;
        }

        public void UnSubscribeEvents()
        {
            PlayerEvents.Verified -= OnPlayerVerified;
        }

        private void OnPlayerVerified(VerifiedEventArgs ev) => ev.Player.AddCompassDisplayComponent();
    }
}
