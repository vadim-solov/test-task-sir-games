using Game.Scripts.Enemies.States;
using Game.Scripts.StateMachine;

namespace Game.Scripts.Enemies
{
    public class EnemyHealth : Health
    {
        private MonoBehaviourStateMachine _stateMachine;
        private EnemyDieState _dieState;

        private void Start()
        {
            _stateMachine = GetComponent<MonoBehaviourStateMachine>();
            _dieState = GetComponent<EnemyDieState>();
        }

        protected override void Die()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }
    }
}
