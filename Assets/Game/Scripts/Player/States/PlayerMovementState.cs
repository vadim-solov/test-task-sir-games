using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(RequireComponent))]
    public class PlayerMovementState : State
    {
        private CharacterController _characterController;
        //TODO Fix this
        private IInputService _inputService;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public override void Enter()
        {
            Debug.Log("enter in movement  state");
        }

        public override void Run()
        {
            Vector3 nexPosition =
                new Vector3(Input.GetAxis("Horizontal"), transform.position.y, Input.GetAxis("Vertical"));
            nexPosition.Normalize();
            _characterController.SimpleMove(nexPosition * 5000f * Time.deltaTime);
        }

        public override void Exit()
        {
            Debug.Log("exit on movement state");
        }
    }
}
