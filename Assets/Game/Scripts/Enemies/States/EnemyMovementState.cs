using Game.Scripts.Configs;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.Services.StateMachine;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.States
{
    [RequireComponent(typeof(IStateMachine))]
    [RequireComponent(typeof(EnemyAttackState))]
    public abstract class EnemyMovementState : MonoBehaviour, IState
    {
        protected IPlayerGameObject _playerGameObject;
        protected float _movementSpeed;
        protected float _stoppingDistance;

        private IStateMachine _stateMachine;
        private EnemyAttackState _attackState;

        private const float RotationSpeed = 10f;

        public abstract void Enter();
        public abstract void Run();
        public abstract void Exit();

        [Inject]
        private void Construct(IPlayerGameObject playerGameObject)
        {
            _playerGameObject = playerGameObject;
        }

        public void Init(EnemyConfig enemyConfig)
        {
            _movementSpeed = enemyConfig.MovementSpeed;
            _stoppingDistance = enemyConfig.StoppingDistance;
            _stateMachine = GetComponent<IStateMachine>();
            _attackState = GetComponent<EnemyAttackState>();
        }

        protected void RotateToTarget()
        {
            Vector3 directionToTarget = _playerGameObject.Instance.transform.position - transform.position;
            directionToTarget.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }

        protected void CheckStoppingDistance()
        {
            float distance = Vector3.Distance(_playerGameObject.Instance.transform.position, transform.position);

            if (_stoppingDistance >= distance)
            {
                _stateMachine.ChangeStateIfNewStateDifferent(_attackState);
            }
        }
    }
}
