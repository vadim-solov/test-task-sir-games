using UnityEngine;

namespace Game.Scripts.UI
{
    public class UIFactory
    {
        private readonly FixedJoystick _fixedJoystickPrefab = Resources.Load<FixedJoystick>("FixedJoystick");

        public FixedJoystick CreateJoystick()
        {
            return Object.Instantiate(_fixedJoystickPrefab);
        }
    }
}
