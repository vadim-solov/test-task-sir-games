using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Game.States
{
    public class AppLoadingState : IState
    {
        public void Enter()
        {
            Debug.Log("loading files...");
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
