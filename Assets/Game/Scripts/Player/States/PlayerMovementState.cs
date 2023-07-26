using Game.Scripts.Services.Input;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(RequireComponent))]
    public class PlayerMovementState : MonoBehaviour, IState
    {
        private CharacterController _characterController;
        //TODO Fix this
        private IInputService _inputService;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void Enter()
        {
            Debug.Log("enter in movement  state");
        }

        public void Run()
        {
            Vector3 nexPosition =
                new Vector3(Input.GetAxis("Horizontal"), transform.position.y, Input.GetAxis("Vertical"));
            nexPosition.Normalize();
            _characterController.SimpleMove(nexPosition * 5000f * Time.deltaTime);
        }

        public void Exit()
        {
            Debug.Log("exit on movement state");
        }
    }
}
