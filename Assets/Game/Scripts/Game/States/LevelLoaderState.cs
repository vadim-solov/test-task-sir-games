using Game.Scripts.Services.Factories.GameObjectFactory;
using Game.Scripts.Services.Factories.UIFactory;
using Game.Scripts.Services.GameStateMachine;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.Game.States
{
    public class LevelLoaderState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameObjectFactory _gameObjectFactory;
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IUIFactoryService _uiFactoryService;

        public LevelLoaderState(GameStateMachine gameStateMachine, IGameObjectFactory gameObjectFactory,
            IPlayerGameObject playerGameObject, IUIFactoryService uiFactoryService)
        {
            _gameStateMachine = gameStateMachine;
            _gameObjectFactory = gameObjectFactory;
            _playerGameObject = playerGameObject;
            _uiFactoryService = uiFactoryService;
        }

        public void Enter()
        {
            _gameObjectFactory.CreateLevel();
            GameObject player = _gameObjectFactory.CreatePlayerAndSetPosition();
            _playerGameObject.SetPlayerInstance(player);
            _gameObjectFactory.CreateAndSetPlayerWeapon(player);
            _gameObjectFactory.CreateCamera(player.transform);
            _gameObjectFactory.CreateEnemiesAndSetPositions();
            _uiFactoryService.CreateGameplayCanvas();
            _gameStateMachine.ChangeState<CountdownState>();
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
