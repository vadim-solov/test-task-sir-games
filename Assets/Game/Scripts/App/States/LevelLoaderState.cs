using Game.Scripts.Services.Factory;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.Services.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class LevelLoaderState : IState
    {
        private readonly IGameObjectFactory _gameObjectFactory;
        private readonly IPlayerGameObject _playerGameObject;

        public LevelLoaderState(IGameObjectFactory gameObjectFactory, IPlayerGameObject playerGameObject)
        {
            _gameObjectFactory = gameObjectFactory;
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
