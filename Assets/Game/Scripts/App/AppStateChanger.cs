using Game.Scripts.App.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.Services.StateMachine;

namespace Game.Scripts.App
{
    public class AppStateChanger
    {
        private readonly AppLoadingState _appLoadingState;
        private readonly LevelLoaderState _levelLoaderState;
        private readonly CountdownState _countdownState;
        private readonly GameplayState _gameplayState;
        private readonly IStateMachine _stateMachine;

        public AppStateChanger(IGameObjectFactory gameObjectFactory, IGameConfigDataProvider gameConfig,
            IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection, CoinSpawner coinSpawner,
            IStateMachine stateMachine)
        {
            _appLoadingState = new AppLoadingState();
            _levelLoaderState = new LevelLoaderState(gameObjectFactory, playerGameObject);
            _countdownState = new CountdownState(gameConfig, allEnemiesCollection, playerGameObject);
            _gameplayState = new GameplayState(playerGameObject, allEnemiesCollection, coinSpawner);
            _stateMachine = stateMachine;
            _countdownState.CountdownIsOver += OnCountdownIsOver;
        }

        public void Disable()
        {
            _countdownState.CountdownIsOver -= OnCountdownIsOver;
        }

        public void Update()
        {
            _stateMachine.CurrentState.Run();
        }

        public void StartApp()
        {
            _stateMachine.Init(_appLoadingState);
            _stateMachine.ChangeStateIfNewStateDifferent(_levelLoaderState);
            _stateMachine.ChangeStateIfNewStateDifferent(_countdownState);
        }

        private void OnCountdownIsOver()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_gameplayState);
        }
    }
}
