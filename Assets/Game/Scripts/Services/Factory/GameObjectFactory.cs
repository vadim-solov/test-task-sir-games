using Game.Scripts.Configs;
using Game.Scripts.Enemies;
using Game.Scripts.Enemies.States;
using Game.Scripts.Player;
using Game.Scripts.Player.States;
using Game.Scripts.PlayerWeapons;
using Game.Scripts.Projectiles;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.SpawnPoint;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Services.Factory
{
    public class GameObjectFactory : IGameObjectFactory
    {
        private readonly IGameConfigDataProvider _gameConfig;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IEnemyConfigGetter _enemyConfigGetter;

        public GameObjectFactory(IGameConfigDataProvider gameConfig, IAllEnemiesCollection allEnemiesCollection,
            IPlayerGameObject playerGameObject, IEnemyConfigGetter enemyConfigGetter)
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

        public GameObject CreatePlayerAndSetPosition()
        {
            PlayerSpawnPoint playerPosition = _gameConfig.AllLevels[0].PlayerSpawnPoint;
            GameObject player = Object.Instantiate(_gameConfig.PlayerConfig.PlayerPrefab,
                playerPosition.transform.position, Quaternion.identity);
            player.GetComponent<PlayerHealth>().Init(_gameConfig.PlayerConfig.MaxHP);
            player.GetComponent<PlayerMovementState>().Init(_gameConfig, _allEnemiesCollection);
            player.GetComponent<PlayerAttackState>().Init(_allEnemiesCollection);
            PlayerIdleState idleState = player.GetComponent<PlayerIdleState>();
            player.GetComponent<MonoBehaviourStateMachine>().Init(idleState);
            return player;
        }

        public void CreateEnemiesAndSetPositions()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                EnemyConfig enemyConfig = _enemyConfigGetter.GetEnemyConfigByType(enemySpawnPoint.EnemyType);
                GameObject enemy = Object.Instantiate(enemyConfig.EnemyPrefab, enemySpawnPoint.transform.position,
                    enemySpawnPoint.transform.rotation);
                enemy.GetComponent<EnemyHealth>().Init(enemyConfig.MaxHP);
                enemy.GetComponent<EnemyAttackState>().Init(_playerGameObject, enemyConfig, this);
                enemy.GetComponent<EnemyMovementState>().Init(_playerGameObject, enemyConfig);
                enemy.GetComponent<EnemyDieState>().Init(_allEnemiesCollection);
                EnemyIdleState idleState = enemy.GetComponent<EnemyIdleState>();
                enemy.GetComponent<MonoBehaviourStateMachine>().Init(idleState);
                _allEnemiesCollection.AddEnemyToCollection(enemy);
            }
        }

        public void CreateAndSetPlayerWeapon(GameObject player)
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

        public Coin CreateCoin(Vector3 position)
        {
            return Object.Instantiate(_gameConfig.CoinPrefab, position, Quaternion.identity);
        }
    }
}
