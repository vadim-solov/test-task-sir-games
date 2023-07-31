using Game.Scripts.Enemies.States;
using Game.Scripts.Services.StateMachine;

namespace Game.Scripts.Enemies
{
    public class EnemyHealth : Health
    {
        private IStateMachine _stateMachine;
        private EnemyDieState _dieState;

        private void Start()
        {
            _stateMachine = GetComponent<IStateMachine>();
            _dieState = GetComponent<EnemyDieState>();
        }

        protected override void Die()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }
    }
}
