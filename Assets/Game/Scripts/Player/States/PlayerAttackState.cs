using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    public class PlayerAttackState : MonoBehaviourState
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
