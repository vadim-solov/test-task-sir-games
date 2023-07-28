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
        [SerializeField]
        private Transform _attackPoint;

        private IPlayerGameObject _playerGameObject;
        private float _waitingTimeAfterAttack;
        private GameObjectFactory _gameObjectFactory;

        private const float RotationSpeed = 10f;

        public event Action AttackComplete;

        public void Init(IPlayerGameObject playerGameObject, EnemyConfig enemyConfig,
            GameObjectFactory gameObjectFactory)
        {
            _playerGameObject = playerGameObject;
            _waitingTimeAfterAttack = enemyConfig.WaitingTimeAfterAttack;
            _gameObjectFactory = gameObjectFactory;
        }

        public void Enter()
        {
            StartCoroutine(StartAttack());
        }

        public void Run()
        {
            TurnToTarget();
        }

        public void Exit()
        {
            StopCoroutine(StartAttack());
        }

        private IEnumerator StartAttack()
        {
            Attack();
            yield return new WaitForSeconds(_waitingTimeAfterAttack);
            AttackComplete?.Invoke();
        }

        private void Attack()
        {
            Debug.Log("attack");
            //_gameObjectFactory.CreateProjectilePlayerWeapon()
        }

        private void TurnToTarget()
        {
            Vector3 directionToTarget = _playerGameObject.Instance.transform.position - transform.position;
            directionToTarget.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }
}
