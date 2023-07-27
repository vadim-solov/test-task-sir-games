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
        private Camera _cameraPrefab;
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

        public Camera CameraPrefab => _cameraPrefab;
        public List<Level> AllLevels => _allLevels;
        public PlayerConfig PlayerConfig => _playerConfig;
        public List<PlayerWeapon> PlayerWeaponsPrefabs => _playerWeaponsPrefabs;
        public float WaitingTimeForLevelActivation => _waitingTimeForLevelActivation;
        public List<EnemyConfig> EnemiesConfig => _enemiesConfig;
    }
}
