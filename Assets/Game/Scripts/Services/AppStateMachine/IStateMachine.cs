namespace Game.Scripts.Services.AppStateMachine
{
    public interface IAppStateMachine
    {
        public IState CurrentState { get; }
        public void Init(IState startState);
        public void ChangeStateIfNewStateDifferent(IState newState);
        public void TryChangeState<T>() where T : class, IState;
    }
}
