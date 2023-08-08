using Game.Scripts.Enemies.States;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    [RequireComponent(typeof(EnemyDieState))]
    public class EnemyHealth : Health
    {
        private MonoBehaviourStateMachine _monoBehaviourStateMachine;

        private void Start()
        {
            _monoBehaviourStateMachine = GetComponent<MonoBehaviourStateMachine>();
        }

        protected override void Die()
        {
            _monoBehaviourStateMachine.ChangeState<EnemyDieState>();
        }
    }
}
