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
            MoveToNextPosition();
            TurnToDirectionMovement();
        }

        public void Exit()
        {
            Debug.Log("exit on movement state");
        }

        private void MoveToNextPosition()
        {
            Vector3 nexPosition =
                new Vector3(Input.GetAxis("Horizontal"), transform.position.y, Input.GetAxis("Vertical"));
            nexPosition.Normalize();
            _characterController.SimpleMove(nexPosition * 5000f * Time.deltaTime); //TODO set speed in config
        }

        private void TurnToDirectionMovement()
        {
            Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
