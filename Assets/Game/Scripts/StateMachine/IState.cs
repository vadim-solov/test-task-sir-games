namespace Game.Scripts.StateMachine
{
    public interface IState
    {
        public abstract void Enter();

        public abstract void Run();

        public abstract void Exit();
    }
}
