namespace Game.Scripts.StateMachine
{
    public interface IState
    {
        public void Enter();

        public void Run();

        public void Exit();
    }
}
