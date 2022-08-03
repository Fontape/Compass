using System.ComponentModel;
using Compass.API.Enums;
using Exiled.API.Interfaces;

namespace Compass
{
    public class Config : IConfig
    {
        [Description("Indicates plugin is enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Setups the compass visibility. Allowed values: Squads, FirearmHolders, Humans")]
        public CompassVisibilityMode CompassMode { get; set; } = CompassVisibilityMode.Humans;
    }
}