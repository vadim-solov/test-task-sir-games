using Game.Scripts.Services.AppStateMachine;
using UnityEngine;

namespace Game.Scripts
{
    public class MonoBehaviourStateMachine : MonoBehaviour
    {
        public IState CurrentState { get; private set; }

        public void Init(IState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeStateIfNewStateDifferent(IState newState)
        {
            if (newState.GetType() == CurrentState.GetType())
            {
                return;
            }

            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        private void Update()
        {
            CurrentState.Run();
        }
    }
}
