using Game.Scripts.Configs;
using Game.Scripts.SpawnPoint;
using UnityEngine;

namespace Game.Scripts
{
    public class GameObjectFactory
    {
        private readonly GameConfig _gameConfig;

        public GameObjectFactory(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public void CreateLevel()
        {
            Object.Instantiate(_gameConfig.AllLevels[0].LevelPrefab);
        }

        public void CreatePlayerAndSetPosition()
        {
            PlayerSpawnPoint playerPosition = _gameConfig.AllLevels[0].PlayerSpawnPoint;
            Object.Instantiate(_gameConfig.PlayerPrefab, playerPosition.transform.position, Quaternion.identity);
        }

        public void CreateEnemies()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                Object.Instantiate(enemySpawnPoint.EnemyPrefab, enemySpawnPoint.transform.position,
                    Quaternion.identity);
            }
        }
    }
}
