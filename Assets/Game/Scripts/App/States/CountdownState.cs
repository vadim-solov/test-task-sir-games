using System;
using Game.Scripts.Configs;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class CountdownState : IState
    {
        private float _timer;

        private readonly float _waitingTimeForLevelActivation;

        public event Action CountdownIsOver;

        public CountdownState(GameConfig gameConfig)
        {
            _waitingTimeForLevelActivation = gameConfig.WaitingTimeForLevelActivation;
        }

        public void Enter()
        {
            _timer = 0f;
        }

        public void Run()
        {
            IncreaseTimer();
            CheckTimerAndTryInvokeEvent();
        }

        public void Exit()
        {
        }

        private void IncreaseTimer()
        {
            _timer += Time.deltaTime;
        }

        private void CheckTimerAndTryInvokeEvent()
        {
            if (_timer >= _waitingTimeForLevelActivation)
            {
                CountdownIsOver?.Invoke();
            }
        }
    }
}
