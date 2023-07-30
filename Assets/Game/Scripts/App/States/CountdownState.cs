using System;
using Game.Scripts.Configs;
using Game.Scripts.Enemies.States;
using Game.Scripts.Player.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class CountdownState : IState
    {
        private float _timer;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IPlayerGameObject _playerGameObject;

        private readonly float _waitingTimeForLevelActivation;

        public event Action CountdownIsOver;

        public CountdownState(GameConfig gameConfig, IAllEnemiesCollection allEnemiesCollection,
            IPlayerGameObject playerGameObject)
        {
            _waitingTimeForLevelActivation = gameConfig.WaitingTimeForLevelActivation;
            _allEnemiesCollection = allEnemiesCollection;
            _playerGameObject = playerGameObject;
        }

        public void Enter()
        {
            ResetTimer();
            SetIdleStateForPlayer();
            SetIdleStateForAllEnemies();
        }

        public void Run()
        {
            IncreaseTimer();
            CheckTimerAndTryInvokeEvent();
        }

        public void Exit()
        {
        }

        private void ResetTimer()
        {
            _timer = 0f;
        }

        private void SetIdleStateForPlayer()
        {
            MonoBehaviourStateMachine stateMachine =
                _playerGameObject.Instance.GetComponent<MonoBehaviourStateMachine>();
            PlayerIdleState idleState = _playerGameObject.Instance.GetComponent<PlayerIdleState>();
            stateMachine.Init(idleState);
        }

        private void SetIdleStateForAllEnemies()
        {
            foreach (GameObject enemy in _allEnemiesCollection.AllEnemies)
            {
                MonoBehaviourStateMachine stateMachine = enemy.GetComponent<MonoBehaviourStateMachine>();
                EnemyIdleState idleState = enemy.GetComponent<EnemyIdleState>();
                stateMachine.Init(idleState);
            }
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
