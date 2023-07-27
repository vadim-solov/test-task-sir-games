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

        private Health _health;

        protected StateMachine.StateMachine _stateMachine;

        public virtual void Init(IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject)
        {
            _health = GetComponent<Health>();
            _stateMachine = new StateMachine.StateMachine();
            _dieState.Init(this, allEnemiesCollection);
            _stateMachine.Init(_idleState);
            _health.Die += OnDie;
        }

        private void OnDisable()
        {
            _health.Die -= OnDie;
        }

        private void Update()
        {
            _stateMachine.CurrentState.Run();
        }

        private void OnDie()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }
    }
}
