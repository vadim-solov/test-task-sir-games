using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        public abstract Vector3 Axis { get; protected set; }
        public abstract void Update();
    }
}
