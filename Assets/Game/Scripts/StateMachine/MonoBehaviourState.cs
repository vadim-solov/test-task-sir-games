using UnityEngine;

namespace Game.Scripts.StateMachine

{
    public abstract class MonoBehaviourState : MonoBehaviour, IState
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
