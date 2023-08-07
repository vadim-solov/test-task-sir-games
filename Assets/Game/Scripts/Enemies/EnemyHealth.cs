using Game.Scripts.Enemies.States;
using Game.Scripts.Services.AppStateMachine;

namespace Game.Scripts.Enemies
{
    public class EnemyHealth : Health
    {
        private IAppStateMachine _appStateMachine;
        private EnemyDieState _dieState;

        private void Start()
        {
            _appStateMachine = GetComponent<IAppStateMachine>();
            _dieState = GetComponent<EnemyDieState>();
        }

        protected override void Die()
        {
            _appStateMachine.ChangeStateIfNewStateDifferent(_dieState);
        }
    }
}
