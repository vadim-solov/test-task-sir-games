using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public interface IInputService
    {
        public Vector3 Axis { get; }
        public void Update();
    }
}
