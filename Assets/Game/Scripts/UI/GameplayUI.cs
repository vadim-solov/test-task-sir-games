using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private FixedJoystick _fixedJoystick;

        private void Update()
        {
            InputService.Axis = new Vector3(_fixedJoystick.Horizontal, 0f, _fixedJoystick.Vertical);
        }
    }
}
