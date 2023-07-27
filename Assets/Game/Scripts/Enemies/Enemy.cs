using Game.Scripts.Enemies.States;
using Game.Scripts.Services.EnemiesCollection;
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

        private Health _health;
        private StateMachine.StateMachine _stateMachine;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _health.Die += OnDie;
        }

        private void OnDisable()
        {
            _health.Die -= OnDie;
        }

        public void Init(IAllEnemiesCollection allEnemiesCollection)
        {
            _stateMachine = new StateMachine.StateMachine();
            _dieState.Init(this, allEnemiesCollection);
            _stateMachine.Init(_idleState);
        }

        private void OnDie()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }
    }
}
