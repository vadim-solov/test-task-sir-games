using Game.Scripts.Configs;
using Game.Scripts.Enemies.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    [RequireComponent(typeof(Health))]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        private EnemyIdleState _idleState;
        [SerializeField]
        private EnemyDieState _dieState;
        [SerializeField]
        private EnemyMovementState _movementState;
        [SerializeField]
        private EnemyAttackState _attackState;

        private Health _health;
        private StateMachine.StateMachine _stateMachine;

        public void Init(IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject,
            EnemyConfig enemyConfig)
        {
            _health = GetComponent<Health>();
            _stateMachine = new StateMachine.StateMachine();
            _dieState.Init(this, allEnemiesCollection);
            _movementState.Init(playerGameObject, enemyConfig);
            _attackState.Init(playerGameObject, enemyConfig);
            _stateMachine.Init(_movementState);
            _health.Die += OnDie;
            _movementState.StoppingDistanceAchieved += OnStoppingDistanceAchieved;
            _attackState.AttackComplete += OnAttackComplete;
        }

        private void OnDisable()
        {
            _health.Die -= OnDie;
            _movementState.StoppingDistanceAchieved -= OnStoppingDistanceAchieved;
            _attackState.AttackComplete -= OnAttackComplete;
        }

        private void Update()
        {
            _stateMachine.CurrentState.Run();
        }

        private void OnDie()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }

        private void OnStoppingDistanceAchieved()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_attackState);
        }

        private void OnAttackComplete()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_movementState);
        }
    }
}
