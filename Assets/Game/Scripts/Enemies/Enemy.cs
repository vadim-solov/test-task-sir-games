using Game.Scripts.Enemies.States;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    [RequireComponent(typeof(Health))]
    public abstract class Enemy : MonoBehaviour
    {
        private StateMachine.StateMachine _stateMachine;
        private EnemyIdleState _idleState;
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void Init()
        {
            _idleState = new EnemyIdleState();
            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.Init(_idleState);
            //_health
        }
    }
}
