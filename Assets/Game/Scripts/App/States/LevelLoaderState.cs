using Game.Scripts.Services.AppStateMachine;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class LevelLoaderState : IState
    {
        private readonly AppStateMachine _appStateMachine;
        private readonly IGameObjectFactory _gameObjectFactory;
        private readonly IPlayerGameObject _playerGameObject;

        public LevelLoaderState(AppStateMachine appStateMachine, IGameObjectFactory gameObjectFactory,
            IPlayerGameObject playerGameObject)
        {
            _appStateMachine = appStateMachine;
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
            _appStateMachine.ChangeState<CountdownState>();
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
