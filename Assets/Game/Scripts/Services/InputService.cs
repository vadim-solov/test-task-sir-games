using UnityEngine;

namespace Game.Scripts.Services
{
    public class InputService : IInputService
    {
        public Vector3 Axis { get; private set; }

        public void Update()
        {
            Axis = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }
    }

    public interface IInputService
    {
        public Vector3 Axis { get; }
        public void Update();
    }
}
