using Game.Scripts.App.States;
using Game.Scripts.Configs;
using UnityEngine;

namespace Game.Scripts.App
{
    public class AppStateChanger
    {
        private readonly AppLoadingState _appLoadingState;
        private readonly LevelLoaderState _levelLoaderState;
        private readonly CountdownState _countdownState;
        private readonly StateMachine.StateMachine _stateMachine;

        public AppStateChanger(GameObjectFactory gameObjectFactory, GameConfig gameConfig)
        {
            _appLoadingState = new AppLoadingState();
            _levelLoaderState = new LevelLoaderState(gameObjectFactory);
            _countdownState = new CountdownState(gameConfig);
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
            Debug.Log("OnCountdownIsOver");
        }
    }
}
