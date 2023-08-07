namespace Game.Scripts.Services.AppStateMachine
{
    public interface IState
    {
        public abstract void Enter();

        public abstract void Run();

        public abstract void Exit();
    }
}
