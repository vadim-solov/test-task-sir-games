using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    public class PlayerIdleState : MonoBehaviour, IState
    {
        public void Enter()
        {
            Debug.Log("enter in idle state");
        }

        public void Run()
        {
            Debug.Log("idle state");
        }

        public void Exit()
        {
            Debug.Log("exit on idle state");
        }
    }
}
