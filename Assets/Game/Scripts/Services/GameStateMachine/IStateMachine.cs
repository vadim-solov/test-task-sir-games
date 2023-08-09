namespace Game.Scripts.Services.GameStateMachine
{
    public interface IStateMachine
    {
        public IState CurrentState { get; }

        public void ChangeState<T>() where T : class, IState;
    }
}
