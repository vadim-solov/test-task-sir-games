namespace Game.Scripts.Services.StateMachine
{
    public class StateMachine : IStateMachine
    {
        public IState CurrentState { get; private set; }

        public void Init(IState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeStateIfNewStateDifferent(IState newState)
        {
            if (newState.GetType() == CurrentState.GetType())
            {
                return;
            }

            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
