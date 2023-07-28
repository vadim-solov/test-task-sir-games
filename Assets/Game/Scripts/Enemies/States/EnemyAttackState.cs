using System;
using System.Collections;
using Game.Scripts.Configs;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class EnemyAttackState : MonoBehaviour, IState
    {
        private IPlayerGameObject _playerGameObject;
        private float _timer;
        private float _attackReloadTime;
        private bool _isAttackedInProgress;
        private float _waitingTimeAfterAttack;

        public event Action AttackComplete;

        public void Init(IPlayerGameObject playerGameObject, EnemyConfig enemyConfig)
        {
            _playerGameObject = playerGameObject;
            _attackReloadTime = enemyConfig.AttackReloadTime;
            _waitingTimeAfterAttack = enemyConfig.WaitingTimeAfterAttack;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void Enter()
        {
        }

        public void Run()
        {
            TryAttack();
        }

        public void Exit()
        {
        }

        private void TryAttack()
        {
            if (_isAttackedInProgress)
            {
                return;
            }

            if (_timer < _attackReloadTime)
            {
                return;
            }

            StartCoroutine(StartAttack());
        }

        private IEnumerator StartAttack()
        {
            _isAttackedInProgress = true;
            yield return new WaitForSeconds(_waitingTimeAfterAttack);
            _timer = 0f;
            _isAttackedInProgress = false;
            AttackComplete?.Invoke();
        }
    }
}
