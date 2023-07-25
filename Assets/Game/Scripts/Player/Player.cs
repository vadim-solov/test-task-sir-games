using Game.Scripts.Services;
using UnityEngine;

namespace Game.Scripts.Player
{
    [RequireComponent(typeof(RequireComponent))]
    public class Player : MonoBehaviour
    {
        private CharacterController _characterController;

        private IInputService _inputService;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 nexPosition = new Vector3(_inputService.Axis.x, transform.position.y, _inputService.Axis.z);
            nexPosition.Normalize();
            _characterController.SimpleMove(_inputService.Axis * 5000f * Time.deltaTime);
        }
    }
}
