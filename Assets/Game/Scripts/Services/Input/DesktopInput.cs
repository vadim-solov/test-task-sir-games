using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public class DesktopInput : InputService
    {
        public override Vector3 Axis { get; protected set; }

        public override void Update()
        {
            Axis = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));
        }
    }
}
