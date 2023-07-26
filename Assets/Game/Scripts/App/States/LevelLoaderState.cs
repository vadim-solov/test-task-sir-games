using Game.Scripts.StateMachine;

namespace Game.Scripts.App.States
{
    public class LevelLoaderState : IState
    {
        private readonly GameObjectFactory _gameObjectFactory;

        public LevelLoaderState(GameObjectFactory gameObjectFactory)
        {
            _gameObjectFactory = gameObjectFactory;
        }

        public void Enter()
        {
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
