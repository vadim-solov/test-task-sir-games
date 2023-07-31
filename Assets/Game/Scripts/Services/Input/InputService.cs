using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        private const float Epsilon = 0.001f;

        public abstract Vector2 Axis { get; }

        public bool IsMove()
        {
            return Axis.sqrMagnitude > Epsilon;
        }

        protected Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        }
    }
}
