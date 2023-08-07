using UnityEngine;

namespace Game.Scripts.Services.AppStateMachine
{
    public class MonoBehaviourStateMachine : MonoBehaviour, IAppStateMachine
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

        public void TryChangeState<T>() where T : class, IState
        {
        }

        private void Update()
        {
            CurrentState.Run();
        }
    }
}
