using Compass.API.Interfaces;
using Exiled.API.Interfaces;

namespace Compass
{
    public class WorldSidesTranslations : ITranslation, IReadOnlyWorldSidesTranslations
    {
        public string North { get; set; } = "NORTH";

        public string East { get; set; } = "EAST";

        public string South { get; set; } = "SOUTH";

        public string West { get; set; } = "WEST";
    }
}