using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace RandomHealth
{
    public class RandomHealth : Plugin<Config>
    {
        public static RandomHealth Instance;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 1);

        private Handlers.Spawning Spawning;

        public RandomHealth()
        { }

        public override void OnEnabled()
        {
            Instance = this;

            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            Spawning = new Handlers.Spawning();

            PlayerHandler.Spawning += Spawning.OnSpawning;
        }

        public void UnregisterEvents()
        {
            PlayerHandler.Spawning -= Spawning.OnSpawning;

            Spawning = null;
        }
    }
}