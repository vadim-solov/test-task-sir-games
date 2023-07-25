using Game.Scripts.Player;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private PlayerStatesChanger _playerStatesChanger;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new DesktopInput();
            _playerStatesChanger.Init(_inputService);
        }

        private void Update()
        {
            _inputService.Update();
        }
    }
}
