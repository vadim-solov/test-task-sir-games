namespace Game.Scripts.StateMachine
{
    public abstract class State : IState
    {
        public virtual void Enter()
        {
        }

        public virtual void Run()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
