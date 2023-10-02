using System.Collections.Generic;
using Game.Scripts.PlayerWeapons;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Header("Game")]
        [SerializeField]
        private float _waitingTimeForLevelActivation = 3f;
        [SerializeField]
        private CameraFollowing _cameraPrefab;
        [SerializeField]
        private Coin _coinPrefab;
        [SerializeField]
        private List<Level> _allLevels;
        [Header("Player")]
        [SerializeField]
        private PlayerConfig _playerConfig;
        [SerializeField]
        private List<PlayerWeapon> _playerWeaponsPrefabs;
        [Header("Enemies")]
        [SerializeField]
        private List<EnemyConfig> _enemiesConfig;

        public CameraFollowing CameraPrefab => _cameraPrefab;
        public Coin CoinPrefab => _coinPrefab;
        public List<Level> AllLevels => _allLevels;
        public PlayerConfig PlayerConfig => _playerConfig;
        public List<PlayerWeapon> PlayerWeaponsPrefabs => _playerWeaponsPrefabs;
        public float WaitingTimeForLevelActivation => _waitingTimeForLevelActivation;
        public List<EnemyConfig> EnemiesConfig => _enemiesConfig;
    }
}
