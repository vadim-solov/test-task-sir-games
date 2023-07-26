using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class GameplayState : IState
    {
        private readonly IPlayerGameObject _playerGameObject;

        public GameplayState(IPlayerGameObject playerGameObject)
        {
            _playerGameObject = playerGameObject;
        }

        public void Enter()
        {
            Debug.Log("enter in gameplay state");
            _playerGameObject.Instance.SetAttackState();
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
