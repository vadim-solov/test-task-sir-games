using Game.Scripts.App;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.EnemiesGetter;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.Input;
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

        private void Awake()
        {
            Init();
            _appStateChanger.StartApp();
        }

        [Inject]
        private void Construct(IGameConfigDataProvider gameConfigDataProvider)
        {
            _gameConfigDataProvider = gameConfigDataProvider;
        }

        private void Init()
        {
            IEnemyConfigGetter enemyConfigGetter = new EnemyConfigGetter(_gameConfigDataProvider);
            IAllEnemiesCollection allEnemiesCollection = new AllEnemiesCollection();
            IPlayerGameObject playerGameObject = new PlayerGameObject();
            IGameObjectFactory gameObjectFactory = new GameObjectFactory(_gameConfigDataProvider, allEnemiesCollection,
                playerGameObject, enemyConfigGetter, GetInputService());
            CoinSpawner coinSpawner = new CoinSpawner(gameObjectFactory);
            _appStateChanger = new AppStateChanger(gameObjectFactory, _gameConfigDataProvider, playerGameObject,
                allEnemiesCollection, coinSpawner, new StateMachine());
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

        private IInputService GetInputService()
        {
            return Application.isEditor ? (IInputService)new DesktopInput() : new MobileInput();
        }
    }
}
