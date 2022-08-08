namespace Compass.API.Interfaces
{
    public interface IReadOnlyWorldSidesTranslations
    {
        public string North { get; }

        public string East { get; }

        public string South { get; }

        public string West { get; }
    }
}