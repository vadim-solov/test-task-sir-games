using Game.Scripts.Services.GameStateMachine;
using UnityEngine;

namespace Game.Scripts.Game.States
{
    public class GameLoadingState : IState
    {
        private readonly IStateMachine _gameStateMachine;

        public GameLoadingState(IStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("loading files...");
            _gameStateMachine.ChangeState<LevelLoaderState>();
        }

        public void Run()
        {
        }

        public void Exit()
        {
            Debug.Log("loading files done!");
        }
    }
}
