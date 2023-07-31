using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public interface IInputService
    {
        public Vector2 Axis { get; }

        public bool IsMove();
    }
}
