namespace Game.Scripts.Services.StateMachine
{
    public interface IStateMachine
    {
        public IState CurrentState { get; }
        public void Init(IState startState);
        public void ChangeStateIfNewStateDifferent(IState newState);
    }
}
