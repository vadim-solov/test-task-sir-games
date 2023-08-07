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
using Game.Scripts.SpawnPoint;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Services.Factory
{
    public class GameObjectFactory : IGameObjectFactory
    {
        private readonly IGameConfigDataProvider _gameConfig;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IEnemyConfigGetter _enemyConfigGetter;
        private readonly DiContainer _diContainer;

        [Inject]
        public GameObjectFactory(IGameConfigDataProvider gameConfig, IAllEnemiesCollection allEnemiesCollection,
            IEnemyConfigGetter enemyConfigGetter, DiContainer diContainer)
        {
            _gameConfig = gameConfig;
            _allEnemiesCollection = allEnemiesCollection;
            _enemyConfigGetter = enemyConfigGetter;
            _diContainer = diContainer;
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

            GameObject player = _diContainer.InstantiatePrefab(_gameConfig.PlayerConfig.PlayerPrefab,
                playerPosition.transform.position, Quaternion.identity, null);
            player.GetComponent<PlayerHealth>().Init(_gameConfig.PlayerConfig.MaxHP);
            PlayerIdleState idleState = player.GetComponent<PlayerIdleState>();
            player.GetComponent<MonoBehaviourStateMachine>().Init(idleState);
            return player;
        }

        public void CreateEnemiesAndSetPositions()
        {
            foreach (EnemySpawnPoint enemySpawnPoint in _gameConfig.AllLevels[0].EnemySpawnPoints)
            {
                EnemyConfig enemyConfig = _enemyConfigGetter.GetEnemyConfigByType(enemySpawnPoint.EnemyType);

                GameObject enemy = _diContainer.InstantiatePrefab(enemyConfig.EnemyPrefab,
                    enemySpawnPoint.transform.position,
                    enemySpawnPoint.transform.rotation, null);

                enemy.GetComponent<EnemyHealth>().Init(enemyConfig.MaxHP);
                enemy.GetComponent<EnemyAttackState>().Init(enemyConfig);
                enemy.GetComponent<EnemyMovementState>().Init(enemyConfig);
                EnemyIdleState idleState = enemy.GetComponent<EnemyIdleState>();
                enemy.GetComponent<MonoBehaviourStateMachine>().Init(idleState);
                _allEnemiesCollection.AddEnemyToCollection(enemy);
            }
        }

        public void CreateAndSetPlayerWeapon(GameObject player)
        {
            PlayerWeapon playerWeapon =
                _diContainer.InstantiatePrefabForComponent<PlayerWeapon>(_gameConfig.PlayerWeaponsPrefabs[0]);
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
