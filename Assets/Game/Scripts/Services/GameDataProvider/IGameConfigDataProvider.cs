using System.Collections.Generic;
using Game.Scripts.Configs;
using Game.Scripts.PlayerWeapons;
using UnityEngine;

namespace Game.Scripts.Services.GameDataProvider
{
    public interface IGameConfigDataProvider
    {
        public Camera CameraPrefab { get; }
        public Coin CoinPrefab { get; }
        public List<Level> AllLevels { get; }
        public PlayerConfig PlayerConfig { get; }
        public List<PlayerWeapon> PlayerWeaponsPrefabs { get; }
        public float WaitingTimeForLevelActivation { get; }
        public List<EnemyConfig> EnemiesConfig { get; }
    }
}
