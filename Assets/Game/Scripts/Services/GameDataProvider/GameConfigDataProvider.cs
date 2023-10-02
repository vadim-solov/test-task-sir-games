using System.Collections.Generic;
using Game.Scripts.Configs;
using Game.Scripts.PlayerWeapons;

namespace Game.Scripts.Services.GameDataProvider
{
    public class GameConfigDataProvider : IGameConfigDataProvider
    {
        public CameraFollowing CameraPrefab { get; }
        public Coin CoinPrefab { get; }
        public List<Level> AllLevels { get; }
        public PlayerConfig PlayerConfig { get; }
        public List<PlayerWeapon> PlayerWeaponsPrefabs { get; }
        public float WaitingTimeForLevelActivation { get; }
        public List<EnemyConfig> EnemiesConfig { get; }

        public GameConfigDataProvider(GameConfig gameConfig)
        {
            CameraPrefab = gameConfig.CameraPrefab;
            CoinPrefab = gameConfig.CoinPrefab;
            AllLevels = gameConfig.AllLevels;
            PlayerConfig = gameConfig.PlayerConfig;
            PlayerWeaponsPrefabs = gameConfig.PlayerWeaponsPrefabs;
            WaitingTimeForLevelActivation = gameConfig.WaitingTimeForLevelActivation;
            EnemiesConfig = gameConfig.EnemiesConfig;
        }
    }
}
