namespace Game.Scripts.Services.GameStateMachine
{
    public interface IState
    {
        public abstract void Enter();
        public abstract void Run();
        public abstract void Exit();
    }
}
