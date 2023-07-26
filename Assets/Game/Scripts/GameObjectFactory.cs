using Game.Scripts.Configs;
using Game.Scripts.Enemy;
using Game.Scripts.Services.Input;
using Game.Scripts.SpawnPoint;
using UnityEngine;

namespace Game.Scripts
{
    public class GameObjectFactory
    {
        private readonly GameConfig _gameConfig;
        private readonly IInputService _inputService;
        private readonly AllEnemiesCollection _allEnemiesCollection;

        public GameObjectFactory(GameConfig gameConfig, IInputService inputService,
            AllEnemiesCollection allEnemiesCollection)
        {
            _gameConfig = gameConfig;
            _inputService = inputService;
            _allEnemiesCollection = allEnemiesCollection;
        }

        public Camera CreateCamera(Transform cameraTargetTransform)
        {
            Camera camera = Object.Instantiate(_gameConfig.CameraPrefab);
            CameraFollowing cameraFollowing = camera.GetComponent<CameraFollowing>();
            cameraFollowing.Init(cameraTargetTransform.transform);
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
            player.Init(_inputService, _allEnemiesCollection);
            return player;
        }

        public void CreateEnemiesAndSetPositions()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                Enemy.Enemy enemy = Object.Instantiate(enemySpawnPoint.EnemyPrefab, enemySpawnPoint.transform.position,
                    Quaternion.identity);
                _allEnemiesCollection.AddEnemyToList(enemy);
            }
        }
    }
}
