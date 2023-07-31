using System.Collections;
using Game.Scripts.Configs;
using Game.Scripts.Projectiles;
using Game.Scripts.Services.Factory;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.Services.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    [RequireComponent(typeof(IStateMachine))]
    [RequireComponent(typeof(EnemyMovementState))]
    public class EnemyAttackState : MonoBehaviour, IState
    {
        [SerializeField]
        private Transform _attackPoint;

        private IPlayerGameObject _playerGameObject;
        private float _waitingTimeAfterAttack;
        private IGameObjectFactory _gameObjectFactory;
        private EnemyConfig _enemyConfig;
        private IStateMachine _stateMachine;
        private EnemyMovementState _movementState;

        private const float RotationSpeed = 10f;

        public void Init(IPlayerGameObject playerGameObject, EnemyConfig enemyConfig,
            IGameObjectFactory gameObjectFactory)
        {
            _enemyConfig = enemyConfig;
            _playerGameObject = playerGameObject;
            _waitingTimeAfterAttack = _enemyConfig.WaitingTimeAfterAttack;
            _gameObjectFactory = gameObjectFactory;
            _stateMachine = GetComponent<IStateMachine>();
            _movementState = GetComponent<EnemyMovementState>();
        }

        public void Enter()
        {
            StartCoroutine(AttackAndChangeState());
        }

        public void Run()
        {
            TurnToTarget();
        }

        public void Exit()
        {
            StopCoroutine(AttackAndChangeState());
        }

        private IEnumerator AttackAndChangeState()
        {
            Attack();
            yield return new WaitForSeconds(_waitingTimeAfterAttack);
            _stateMachine.ChangeStateIfNewStateDifferent(_movementState);
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
