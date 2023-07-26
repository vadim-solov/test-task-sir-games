using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class GameplayState : IState
    {
        public void Enter()
        {
            Debug.Log("enter in gameplay state");
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
