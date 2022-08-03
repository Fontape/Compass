using System.ComponentModel;
using Compass.API.Enums;

namespace Compass
{
    public class Config : Exiled.API.Interfaces.IConfig
    {
        [Description("Indicates plugin enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Setups the compass visibility. Allowed values: Squads, FirearmHolders, Humans")]
        public CompassVisibilityMode CompassMode { get; set; } = CompassVisibilityMode.Humans;
    }
}