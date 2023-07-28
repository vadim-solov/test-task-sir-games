using Game.Scripts.App;
using Game.Scripts.Configs;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.UI;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private GameConfig _gameConfig;

        private AppStateChanger _appStateChanger;

        private void Awake()
        {
            IEnemyConfigGetter enemyConfigGetter = new EnemyConfigGetter(_gameConfig);
            IAllEnemiesCollection allEnemiesCollection = new AllEnemiesCollection();
            IPlayerGameObject playerGameObject = new PlayerGameObject();
            GameObjectFactory gameObjectFactory =
                new GameObjectFactory(_gameConfig, allEnemiesCollection, playerGameObject,
                    enemyConfigGetter);
            CoinSpawner coinSpawner = new CoinSpawner(gameObjectFactory);
            _appStateChanger =
                new AppStateChanger(gameObjectFactory, _gameConfig, playerGameObject, allEnemiesCollection,
                    coinSpawner);
            UIFactory uiFactory = new UIFactory();
            uiFactory.CreateGameplayCanvas();
            _appStateChanger.StartApp();
        }

        private void OnDisable()
        {
            _appStateChanger.Disable();
        }

        private void Update()
        {
            _appStateChanger.Update();
        }
    }
}
