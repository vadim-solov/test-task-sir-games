using Game.Scripts.Configs;
using Game.Scripts.Enemies;
using Game.Scripts.Player;
using Game.Scripts.PlayerWeapons;
using Game.Scripts.Projectiles;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.SpawnPoint;
using UnityEngine;

namespace Game.Scripts
{
    public class GameObjectFactory
    {
        private readonly GameConfig _gameConfig;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IEnemyConfigGetter _enemyConfigGetter;

        public GameObjectFactory(GameConfig gameConfig,
            IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject,
            IEnemyConfigGetter enemyConfigGetter)
        {
            _gameConfig = gameConfig;
            _allEnemiesCollection = allEnemiesCollection;
            _playerGameObject = playerGameObject;
            _enemyConfigGetter = enemyConfigGetter;
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
            player.Init(_allEnemiesCollection, _gameConfig);
            _playerGameObject.SetPlayer(player);
            return player;
        }

        public void CreateEnemiesAndSetPositions()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                EnemyConfig enemyConfig = _enemyConfigGetter.GetEnemyConfigByType(enemySpawnPoint.EnemyType);
                Enemy enemy = Object.Instantiate(enemyConfig.EnemyPrefab, enemySpawnPoint.transform.position,
                    enemySpawnPoint.transform.rotation);
                enemy.Init(_allEnemiesCollection, _playerGameObject, enemyConfig, this);
                _allEnemiesCollection.AddEnemyToCollection(enemy);
            }
        }

        public void CreateAndSetPlayerWeapon(Player.Player player)
        {
            PlayerWeapon playerWeapon = Object.Instantiate(_gameConfig.PlayerWeaponsPrefabs[0]);
            playerWeapon.Init(this, _gameConfig);
            CurrentPlayerWeapon playerWeaponComponent = player.GetComponent<CurrentPlayerWeapon>();
            playerWeaponComponent.SetWeapon(playerWeapon);
        }

        public Projectile CreateProjectile(Projectile projectile,
            Vector3 attackPointPosition)
        {
            return Object.Instantiate(projectile, attackPointPosition, Quaternion.identity);
        }

        public void CreateCoin(Vector3 position)
        {
            Object.Instantiate(_gameConfig.CoinPrefab, position, Quaternion.identity);
        }
    }
}
