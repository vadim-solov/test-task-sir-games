using UnityEngine;

namespace Game.Scripts.Player.States
{
    public class PlayerIdleState : State
    {
        public override void Enter()
        {
            Debug.Log("enter in idle state");
        }

        public override void Run()
        {
            Debug.Log("idle state");
        }

        public override void Exit()
        {
            Debug.Log("exit on idle state");
        }
    }
}
