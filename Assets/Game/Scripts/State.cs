using UnityEngine;

namespace Game.Scripts
{
    public abstract class State : MonoBehaviour
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
