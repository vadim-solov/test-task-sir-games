using Game.Scripts.Configs;
using Game.Scripts.Services.Input;
using Game.Scripts.SpawnPoint;
using UnityEngine;

namespace Game.Scripts
{
    public class GameObjectFactory
    {
        private readonly GameConfig _gameConfig;
        private readonly IInputService _inputService;

        public GameObjectFactory(GameConfig gameConfig, IInputService inputService)
        {
            _gameConfig = gameConfig;
            _inputService = inputService;
        }

        public Camera CreateCamera()
        {
            Camera camera = Object.Instantiate(_gameConfig.CameraPrefab);
            return camera;
        }

        public void CreateLevel()
        {
            Object.Instantiate(_gameConfig.AllLevels[0].LevelPrefab);
        }

        public Player.Player CreatePlayerAndSetPosition()
        {
            PlayerSpawnPoint playerPosition = _gameConfig.AllLevels[0].PlayerSpawnPoint;
            Player.Player player = Object.Instantiate(_gameConfig.PlayerPrefab, playerPosition.transform.position,
                Quaternion.identity);
            player.GetComponent<Player.Player>();
            player.Init(_inputService);
            return player;
        }

        public void CreateEnemiesAndSetPositions()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                Object.Instantiate(enemySpawnPoint.EnemyPrefab, enemySpawnPoint.transform.position,
                    Quaternion.identity);
            }
        }
    }
}