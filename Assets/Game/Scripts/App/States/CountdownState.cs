using Game.Scripts.Enemies.States;
using Game.Scripts.Player.States;
using Game.Scripts.Services.AppStateMachine;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class CountdownState : IState
    {
        private float _timer;
        private readonly AppStateMachine _appStateMachine;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly IPlayerGameObject _playerGameObject;

        private readonly float _waitingTimeForLevelActivation;

        public CountdownState(AppStateMachine appStateMachine, IGameConfigDataProvider gameConfig,
            IAllEnemiesCollection allEnemiesCollection,
            IPlayerGameObject playerGameObject)
        {
            _waitingTimeForLevelActivation = gameConfig.WaitingTimeForLevelActivation;
            _appStateMachine = appStateMachine;
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
            IAppStateMachine appStateMachine =
                _playerGameObject.Instance.GetComponent<IAppStateMachine>();
            PlayerIdleState idleState = _playerGameObject.Instance.GetComponent<PlayerIdleState>();
            appStateMachine.ChangeStateIfNewStateDifferent(idleState);
        }

        private void SetIdleStateForAllEnemies()
        {
            foreach (GameObject enemy in _allEnemiesCollection.AllEnemies)
            {
                IAppStateMachine appStateMachine = enemy.GetComponent<IAppStateMachine>();
                EnemyIdleState idleState = enemy.GetComponent<EnemyIdleState>();
                appStateMachine.ChangeStateIfNewStateDifferent(idleState);
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
                _appStateMachine.TryChangeState<GameplayState>();
            }
        }
    }
}
