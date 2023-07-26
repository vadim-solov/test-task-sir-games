using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    public class PlayerAttackState : MonoBehaviour, IState
    {
        public void Enter()
        {
            Debug.Log("enter in attack state");
        }

        public void Run()
        {
            Debug.Log("attack state");
        }

        public void Exit()
        {
            Debug.Log("exit on attack state");
        }
    }
}
