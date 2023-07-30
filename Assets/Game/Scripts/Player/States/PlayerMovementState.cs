using Game.Scripts.Configs;
using Game.Scripts.Services.Input;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(MonoBehaviourStateMachine))]
    [RequireComponent(typeof(PlayerAttackState))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementState : MonoBehaviour, IState
    {
        private float _movementSpeed;
        private MonoBehaviourStateMachine _stateMachine;
        private PlayerAttackState _attackState;
        private CharacterController _characterController;

        private const float RotationSpeed = 10f;

        public void Init(GameConfig gameConfig)
        {
            _movementSpeed = gameConfig.PlayerConfig.MovementSpeed;
            _stateMachine = GetComponent<MonoBehaviourStateMachine>();
            _attackState = GetComponent<PlayerAttackState>();
            _characterController = GetComponent<CharacterController>();
        }

        public void Enter()
        {
        }

        public void Run()
        {
            ChangeStateIfNotMove();
            MoveToNextPosition();
            TryTurnToDirectionMovement();
        }

        public void Exit()
        {
        }

        private void ChangeStateIfNotMove()
        {
            if (!InputService.IsMove())
            {
                _stateMachine.ChangeStateIfNewStateDifferent(_attackState);
            }
        }

        private void MoveToNextPosition()
        {
            Vector3 nexPosition = new Vector3(InputService.Axis.x, transform.position.y, InputService.Axis.z);
            nexPosition.Normalize();
            _characterController.SimpleMove(nexPosition * _movementSpeed * Time.deltaTime);
        }

        private void TryTurnToDirectionMovement()
        {
            Vector3 movementDirection = new Vector3(InputService.Axis.x, 0f, InputService.Axis.z);

            if (movementDirection == Vector3.zero)
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }
    }
}
