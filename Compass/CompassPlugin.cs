using Compass.API.Enums;
using Exiled.API.Features;

namespace Compass
{
    public class CompassPlugin : Plugin<Config, WorldSidesTranslations>
    {
        private PlayerHandler _playerHandler;

        public static CompassVisibilityMode CompassVisibilityMode { get; private set; }

        public override string Name => "Compass";

        public override string Author => "Fontape";

        public override string Prefix => "compass";

        public override void OnEnabled()
        {
            CompassVisibilityMode = Config.CompassMode;
            _playerHandler = new PlayerHandler(Translation);
            _playerHandler.SubscribeEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _playerHandler.UnSubscribeEvents();
            _playerHandler = null;

            base.OnDisabled();
        }
    }
}