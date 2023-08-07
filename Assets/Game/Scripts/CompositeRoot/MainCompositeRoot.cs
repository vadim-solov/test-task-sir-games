using Game.Scripts.App;
using Game.Scripts.Services.CoinsSpawners;
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
        private ICoinSpawner _coinSpawner;

        private void Awake()
        {
            Init();
            _appStateChanger.StartApp();
        }

        [Inject]
        private void Construct(IGameConfigDataProvider gameConfigDataProvider, IEnemyConfigGetter enemyConfigGetter,
            IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject,
            IGameObjectFactory gameObjectFactory, ICoinSpawner coinSpawner)
        {
            _gameConfigDataProvider = gameConfigDataProvider;
            _enemyConfigGetter = enemyConfigGetter;
            _allEnemiesCollection = allEnemiesCollection;
            _playerGameObject = playerGameObject;
            _gameObjectFactory = gameObjectFactory;
            _coinSpawner = coinSpawner;
        }

        private void Init()
        {
            _appStateChanger = new AppStateChanger(_gameObjectFactory, _gameConfigDataProvider, _playerGameObject,
                _allEnemiesCollection, _coinSpawner, new StateMachine());
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
