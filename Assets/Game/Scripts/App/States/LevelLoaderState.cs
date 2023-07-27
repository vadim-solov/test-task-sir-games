using Game.Scripts.Configs;
using Game.Scripts.StateMachine;

namespace Game.Scripts.App.States
{
    public class LevelLoaderState : IState
    {
        private readonly GameObjectFactory _gameObjectFactory;
        private readonly GameConfig _gameConfig;

        public LevelLoaderState(GameObjectFactory gameObjectFactory, GameConfig gameConfig)
        {
            _gameObjectFactory = gameObjectFactory;
            _gameConfig = gameConfig;
        }

        public void Enter()
        {
            _gameObjectFactory.CreateLevel();
            Player.Player player = _gameObjectFactory.CreatePlayerAndSetPosition();
            _gameObjectFactory.CreatePlayerWeapon(player);
            _gameObjectFactory.CreateCamera(player.transform);
            _gameObjectFactory.CreateEnemiesAndSetPositions();
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
