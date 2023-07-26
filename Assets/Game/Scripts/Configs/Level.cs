using System.Collections.Generic;
using Game.Scripts.SpawnPoint;
using UnityEngine;

namespace Game.Scripts.Configs
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private Level _levelPrefab;
        [SerializeField]
        private PlayerSpawnPoint _playerSpawnPoint;
        [SerializeField]
        private List<EnemySpawnPoint> _enemySpawnPoints;

        public Level LevelPrefab => _levelPrefab;
        public PlayerSpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public List<EnemySpawnPoint> EnemySpawnPoints => _enemySpawnPoints;
    }
}
