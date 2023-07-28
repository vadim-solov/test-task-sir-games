using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;

        private IInputService _inputService;

        private UIFactory _uiFactory;

        private void Start()
        {
            _uiFactory = new UIFactory();
            FixedJoystick joystick = _uiFactory.CreateJoystick();
            joystick.transform.SetParent(_canvas.transform);
            _inputService = new MobileInput(joystick);
        }

        private void Update()
        {
            _inputService.Update();
            Debug.Log(_inputService.Axis);
        }
    }
}
