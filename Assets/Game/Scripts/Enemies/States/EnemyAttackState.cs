using System;
using System.Collections;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class EnemyAttackState : MonoBehaviour, IState
    {
        private float _timer;
        private float _attackReloadTime = 0.5f;
        private bool _isAttackedInProgress;

        public event Action AttackComplete;

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
            yield return new WaitForSeconds(3f);
            _timer = 0f;
            _isAttackedInProgress = false;
            AttackComplete?.Invoke();
        }
    }
}
