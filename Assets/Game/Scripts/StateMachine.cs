namespace Game.Scripts
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Init(State startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeStateIfNewStateDifferent(State newState)
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
