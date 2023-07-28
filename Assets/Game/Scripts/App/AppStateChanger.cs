using Game.Scripts.App.States;
using Game.Scripts.Configs;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;

namespace Game.Scripts.App
{
    public class AppStateChanger
    {
        private readonly AppLoadingState _appLoadingState;
        private readonly LevelLoaderState _levelLoaderState;
        private readonly CountdownState _countdownState;
        private readonly GameplayState _gameplayState;
        private readonly StateMachine.StateMachine _stateMachine;

        public AppStateChanger(GameObjectFactory gameObjectFactory, GameConfig gameConfig,
            IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection, CoinSpawner coinSpawner)
        {
            _appLoadingState = new AppLoadingState();
            _levelLoaderState = new LevelLoaderState(gameObjectFactory, gameConfig);
            _countdownState = new CountdownState(gameConfig);
            _gameplayState = new GameplayState(playerGameObject, allEnemiesCollection, coinSpawner);
            _stateMachine = new StateMachine.StateMachine();
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
