using UnityEngine;

namespace Game.Scripts.Services.Input
{
    public class MobileInput : InputService
    {
        private readonly FixedJoystick _fixedJoystick;

        public MobileInput(FixedJoystick fixedJoystick)
        {
            _fixedJoystick = fixedJoystick;
        }

        public override Vector3 Axis { get; protected set; }

        public override void Update()
        {
            Axis = new Vector3(_fixedJoystick.Horizontal, 0f, _fixedJoystick.Vertical);
        }
    }
}
