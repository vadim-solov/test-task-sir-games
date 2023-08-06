using Game.Scripts.App;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.Services.StateMachine;
using Game.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        private IGameConfigDataProvider _gameConfigDataProvider;
        private AppStateChanger _appStateChanger;
        private IEnemyConfigGetter _enemyConfigGetter;
        private IAllEnemiesCollection _allEnemiesCollection;
        private IPlayerGameObject _playerGameObject;
        private IGameObjectFactory _gameObjectFactory;

        private void Awake()
        {
            Init();
            _appStateChanger.StartApp();
        }

        [Inject]
        private void Construct(IGameConfigDataProvider gameConfigDataProvider, IEnemyConfigGetter enemyConfigGetter,
            IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject,
            IGameObjectFactory gameObjectFactory)
        {
            _gameConfigDataProvider = gameConfigDataProvider;
            _enemyConfigGetter = enemyConfigGetter;
            _allEnemiesCollection = allEnemiesCollection;
            _playerGameObject = playerGameObject;
            _gameObjectFactory = gameObjectFactory;
        }

        private void Init()
        {
            CoinSpawner coinSpawner = new CoinSpawner(_gameObjectFactory);
            _appStateChanger = new AppStateChanger(_gameObjectFactory, _gameConfigDataProvider, _playerGameObject,
                _allEnemiesCollection, coinSpawner, new StateMachine());
            UIFactory uiFactory = new UIFactory();
            GameplayUI gameplayUI = uiFactory.CreateGameplayCanvas();
            gameplayUI.Init(_gameConfigDataProvider);
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
