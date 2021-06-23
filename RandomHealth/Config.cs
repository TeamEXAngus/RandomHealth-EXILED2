using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace RandomHealth
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Stores the minimum and maximum random HP for each class. The first value is numerical role ID, the second is min HP, and the third is max HP.")]
        public List<int[]> RoleHealthBounds { get; set; } = new List<int[]> // This is fucking disgusting
        {
            new int[]{1, 100, 120},
            new int[]{6, 100, 120},
            new int[]{15, 100, 120}
        };
    }
}