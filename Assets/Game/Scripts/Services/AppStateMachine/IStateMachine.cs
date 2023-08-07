namespace Game.Scripts.Services.AppStateMachine
{
    public interface IAppStateMachine
    {
        public IState CurrentState { get; }
        public void ChangeState<T>() where T : class, IState;
    }
}
