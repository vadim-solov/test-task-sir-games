using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.CompositeRoot
{
    public class MainCompositeRoot : MonoBehaviour
    {
        [SerializeField]
        private Player.Player _player;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = new DesktopInput();
            _player.Init(_inputService);
        }

        private void Update()
        {
            _inputService.Update();
        }
    }
}
