using System.Collections.Generic;
using Game.Scripts.Configs;
using Game.Scripts.PlayerWeapons;

namespace Game.Scripts.Services.GameDataProvider
{
    public interface IGameConfigDataProvider
    {
        public CameraFollowing CameraPrefab { get; }
        public Coin CoinPrefab { get; }
        public List<Level> AllLevels { get; }
        public PlayerConfig PlayerConfig { get; }
        public List<PlayerWeapon> PlayerWeaponsPrefabs { get; }
        public float WaitingTimeForLevelActivation { get; }
        public List<EnemyConfig> EnemiesConfig { get; }
    }
}
