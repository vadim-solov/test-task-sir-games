using Game.Scripts.Configs;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class LevelLoaderState : IState
    {
        private readonly GameObjectFactory _gameObjectFactory;
        private readonly GameConfig _gameConfig;
        private readonly IPlayerGameObject _playerGameObject;

        public LevelLoaderState(GameObjectFactory gameObjectFactory, GameConfig gameConfig,
            IPlayerGameObject playerGameObject)
        {
            _gameObjectFactory = gameObjectFactory;
            _gameConfig = gameConfig;
            _playerGameObject = playerGameObject;
        }

        public void Enter()
        {
            _gameObjectFactory.CreateLevel();
            GameObject player = _gameObjectFactory.CreatePlayerAndSetPosition();
            _playerGameObject.SetPlayerInstance(player);
            _gameObjectFactory.CreateAndSetPlayerWeapon(player);
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
