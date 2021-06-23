using MEC;
using Exiled.Events.EventArgs;
using System.Collections.Generic;
using UnityEngine;
using Exiled.API.Features;

namespace RandomHealth.Handlers
{
    internal class Spawning
    {
        private List<int[]> ConfigVals => RandomHealth.Instance.Config.RoleHealthBounds;
        private readonly Dictionary<int, int[]> RoleHealthBounds;

        public Spawning()
        {
            RoleHealthBounds = MakeIntoDict(ConfigVals);
        }

        public void OnSpawning(SpawningEventArgs ev)
        {
            var RoleID = (int)ev.RoleType;

            if (RoleHealthBounds.ContainsKey(RoleID))
            {
                Timing.CallDelayed(1f, () => // Prevents changes being cancelled by other plugins
                {
                    var MaxHP = Random.Range(RoleHealthBounds[RoleID][0], RoleHealthBounds[RoleID][1] + 1);
                    ev.Player.MaxHealth = MaxHP;
                    ev.Player.Health = MaxHP;
                    Log.Debug($"Setting HP to {MaxHP}!");
                });
            }
        }

        private Dictionary<int, int[]> MakeIntoDict(List<int[]> input)
        {
            var output = new Dictionary<int, int[]>();

            foreach (var nums in input)
            {
                output.Add(nums[0], new int[] { nums[1], nums[2] });
            }

            return output;
        }
    }
}