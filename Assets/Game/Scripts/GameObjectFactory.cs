using Game.Scripts.Configs;
using Game.Scripts.Player;
using Game.Scripts.PlayerWeapons;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.Input;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.SpawnPoint;
using UnityEngine;

namespace Game.Scripts
{
    public class GameObjectFactory
    {
        private readonly GameConfig _gameConfig;
        private readonly IInputService _inputService;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IEnemyGetter _enemyGetter;

        public GameObjectFactory(GameConfig gameConfig, IInputService inputService,
            IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject, IEnemyGetter enemyGetter)
        {
            _gameConfig = gameConfig;
            _inputService = inputService;
            _allEnemiesCollection = allEnemiesCollection;
            _playerGameObject = playerGameObject;
            _enemyGetter = enemyGetter;
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
            Player.Player player = Object.Instantiate(_gameConfig.PlayerConfig.PlayerPrefab,
                playerPosition.transform.position,
                Quaternion.identity);
            player.GetComponent<Player.Player>();
            player.Init(_inputService, _allEnemiesCollection, _gameConfig);
            _playerGameObject.SetPlayer(player);
            return player;
        }

        public void CreateEnemiesAndSetPositions()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                Enemy.Enemy enemy = Object.Instantiate(_enemyGetter.GetEnemyByType(enemySpawnPoint.EnemyType),
                    enemySpawnPoint.transform.position,
                    Quaternion.identity);
                _allEnemiesCollection.AddEnemyToList(enemy);
            }
        }

        public void CreateAndSetPlayerWeapon(Player.Player player)
        {
            PlayerWeapon playerWeapon = Object.Instantiate(_gameConfig.PlayerWeaponsPrefabs[0]);
            playerWeapon.Init(this, _gameConfig);
            CurrentPlayerWeapon playerWeaponComponent = player.GetComponent<CurrentPlayerWeapon>();
            playerWeaponComponent.SetWeapon(playerWeapon);
        }

        public PlayerWeaponProjectile CreateProjectilePlayerWeapon(PlayerWeaponProjectile playerWeaponProjectile)
        {
            return Object.Instantiate(playerWeaponProjectile);
        }
    }
}
