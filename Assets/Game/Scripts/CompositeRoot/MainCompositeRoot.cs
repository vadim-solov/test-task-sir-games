using Game.Scripts.App;
using Game.Scripts.Configs;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.GameDataProvider;
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
            Init();
            _appStateChanger.StartApp();
        }

        private void Init()
        {
            IGameConfigDataProvider gameConfigDataProvider = new GameConfigDataProvider(_gameConfig);
            IEnemyConfigGetter enemyConfigGetter = new EnemyConfigGetter(gameConfigDataProvider);
            IAllEnemiesCollection allEnemiesCollection = new AllEnemiesCollection();
            IPlayerGameObject playerGameObject = new PlayerGameObject();
            IGameObjectFactory gameObjectFactory =
                new GameObjectFactory(gameConfigDataProvider, allEnemiesCollection, playerGameObject,
                    enemyConfigGetter);
            CoinSpawner coinSpawner = new CoinSpawner(gameObjectFactory);
            _appStateChanger = new AppStateChanger(gameObjectFactory, gameConfigDataProvider, playerGameObject,
                allEnemiesCollection, coinSpawner);
            UIFactory uiFactory = new UIFactory();
            GameplayUI gameplayUI = uiFactory.CreateGameplayCanvas();
            gameplayUI.Init(gameConfigDataProvider);
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
