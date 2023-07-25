using UnityEngine;

namespace Game.Scripts.Player.States
{
    public class PlayerAttackState : State
    {
        public override void Enter()
        {
            Debug.Log("enter in attack state");
        }

        public override void Run()
        {
            Debug.Log("attack state");
        }

        public override void Exit()
        {
            Debug.Log("exit on attack state");
        }
    }
}
