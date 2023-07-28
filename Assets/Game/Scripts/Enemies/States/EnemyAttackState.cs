using System;
using System.Collections;
using Game.Scripts.Configs;
using Game.Scripts.Projectiles;
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
        private EnemyConfig _enemyConfig;

        private const float RotationSpeed = 10f;

        public event Action AttackComplete;

        public void Init(IPlayerGameObject playerGameObject, EnemyConfig enemyConfig,
            GameObjectFactory gameObjectFactory)
        {
            _enemyConfig = enemyConfig;
            _playerGameObject = playerGameObject;
            _waitingTimeAfterAttack = _enemyConfig.WaitingTimeAfterAttack;
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
            Projectile projectile =
                _gameObjectFactory.CreateProjectile(_enemyConfig.ProjectilePrefab, _attackPoint.position);
            projectile.Init(_playerGameObject.Instance.transform.position, _enemyConfig.ProjectileSpeed,
                _enemyConfig.AttackPower);
            projectile.MoveToTarget();
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
