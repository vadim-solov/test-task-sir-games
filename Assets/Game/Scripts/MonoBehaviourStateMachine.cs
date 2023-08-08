using System;
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

        public void ChangeState<T>() where T : MonoBehaviour, IState
        {
            CurrentState.Exit();
            IState state = GetComponent<T>();

            if (state == null)
            {
                throw new Exception("MonoBehaviour state not found");
            }

            CurrentState = GetComponent<T>();
            CurrentState.Enter();
        }

        private void Update()
        {
            CurrentState.Run();
        }
    }
}
