﻿using Game.Scripts.Enemies.States;
using Game.Scripts.Player.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.GameStateMachine;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.Game.States
{
    public class CountdownState : IState
    {
        private float _timer;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IPlayerGameObject _playerGameObject;

        private readonly float _waitingTimeForLevelActivation;

        public CountdownState(GameStateMachine gameStateMachine, IGameConfigDataProvider gameConfig,
            IAllEnemiesCollection allEnemiesCollection,
            IPlayerGameObject playerGameObject)
        {
            _waitingTimeForLevelActivation = gameConfig.WaitingTimeForLevelActivation;
            _gameStateMachine = gameStateMachine;
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
            CheckTimerAndTryChangeState();
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
            MonoBehaviourStateMachine monoBehaviourStateMachine =
                _playerGameObject.Instance.GetComponent<MonoBehaviourStateMachine>();
            monoBehaviourStateMachine.ChangeState<PlayerIdleState>();
        }

        private void SetIdleStateForAllEnemies()
        {
            foreach (GameObject enemy in _allEnemiesCollection.AllEnemies)
            {
                MonoBehaviourStateMachine monoBehaviourStateMachine = enemy.GetComponent<MonoBehaviourStateMachine>();
                monoBehaviourStateMachine.ChangeState<EnemyIdleState>();
            }
        }

        private void IncreaseTimer()
        {
            _timer += Time.deltaTime;
        }

        private void CheckTimerAndTryChangeState()
        {
            if (_timer >= _waitingTimeForLevelActivation)
            {
                _gameStateMachine.ChangeState<GameplayState>();
            }
        }
    }
}
