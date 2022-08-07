using System.ComponentModel;
using Compass.API.Enums;
using Exiled.API.Interfaces;

namespace Compass
{
    public class Config : IConfig
    {
        [Description("Indicates whether the plugin is enabled or not.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Sets the compass visibility mode. Allowed values: SquadMembers, FirearmHolders, Humans")]
        public CompassVisibilityMode CompassMode { get; set; } = CompassVisibilityMode.Humans;
    }
}