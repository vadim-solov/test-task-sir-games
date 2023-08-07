using Game.Scripts.Enemies.States;

namespace Game.Scripts.Enemies
{
    public class EnemyHealth : Health
    {
        private MonoBehaviourStateMachine _monoBehaviourStateMachine;
        private EnemyDieState _dieState;

        private void Start()
        {
            _monoBehaviourStateMachine = GetComponent<MonoBehaviourStateMachine>();
            _dieState = GetComponent<EnemyDieState>();
        }

        protected override void Die()
        {
            _monoBehaviourStateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }
    }
}
