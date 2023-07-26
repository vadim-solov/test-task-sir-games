using Game.Scripts.Game.States;

namespace Game.Scripts.Game
{
    public class AppStateChanger
    {
        private readonly AppLoadingState _appLoadingState;
        private readonly LevelLoaderState _levelLoaderState;
        private readonly StateMachine.StateMachine _stateMachine;

        public AppStateChanger(GameObjectFactory gameObjectFactory)
        {
            _appLoadingState = new AppLoadingState();
            _levelLoaderState = new LevelLoaderState(gameObjectFactory);
            _stateMachine = new StateMachine.StateMachine();
        }

        public void StartApp()
        {
            _stateMachine.Init(_appLoadingState);
            _stateMachine.ChangeStateIfNewStateDifferent(_levelLoaderState);
        }
    }
}
