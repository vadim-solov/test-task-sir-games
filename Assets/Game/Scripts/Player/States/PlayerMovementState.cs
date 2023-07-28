using Game.Scripts.Configs;
using Game.Scripts.Services.Input;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementState : MonoBehaviour, IState
    {
        private CharacterController _characterController;
        private float _movementSpeed;

        private const float RotationSpeed = 10f;

        public void Init(GameConfig gameConfig)
        {
            _movementSpeed = gameConfig.PlayerConfig.MovementSpeed;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void Enter()
        {
        }

        public void Run()
        {
            MoveToNextPosition();
            TurnToDirectionMovement();
        }

        public void Exit()
        {
        }

        private void MoveToNextPosition()
        {
            Vector3 nexPosition = new Vector3(InputService.Axis.x, transform.position.y, InputService.Axis.z);
            nexPosition.Normalize();
            _characterController.SimpleMove(nexPosition * _movementSpeed * Time.deltaTime);
        }

        private void TurnToDirectionMovement()
        {
            Vector3 movementDirection = new Vector3(InputService.Axis.x, 0f, InputService.Axis.z);
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }
    }
}
