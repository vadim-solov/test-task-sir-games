using Game.Scripts.Services.AppStateMachine;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.GameDataProvider;
using Game.Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(IAppStateMachine))]
    [RequireComponent(typeof(PlayerAttackState))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementState : MonoBehaviour, IState
    {
        private float _movementSpeed;
        private IAppStateMachine _appStateMachine;
        private PlayerAttackState _attackState;
        private CharacterController _characterController;
        private IAllEnemiesCollection _allEnemiesCollection;
        private IInputService _inputService;

        private const float RotationSpeed = 10f;

        [Inject]
        private void Construct(IInputService inputService, IGameConfigDataProvider gameConfig,
            IAllEnemiesCollection allEnemiesCollection)
        {
            _inputService = inputService;
            _movementSpeed = gameConfig.PlayerConfig.MovementSpeed;
            _allEnemiesCollection = allEnemiesCollection;
        }

        public void Awake()
        {
            _appStateMachine = GetComponent<IAppStateMachine>();
            _attackState = GetComponent<PlayerAttackState>();
            _characterController = GetComponent<CharacterController>();
        }

        public void Enter()
        {
        }

        public void Run()
        {
            MoveOrChangeState();
        }

        public void Exit()
        {
        }

        private void MoveOrChangeState()
        {
            if (_inputService.IsMove() || _allEnemiesCollection.IsCollectionEmpty)
            {
                MoveToNextPosition();
                TryTurnToDirectionMovement();
            }
            else
            {
                _appStateMachine.ChangeStateIfNewStateDifferent(_attackState);
            }
        }

        private void MoveToNextPosition()
        {
            Vector3 nexPosition = new Vector3(_inputService.Axis.x, transform.position.y, _inputService.Axis.y);
            nexPosition.Normalize();
            _characterController.SimpleMove(nexPosition * _movementSpeed * Time.deltaTime);
        }

        private void TryTurnToDirectionMovement()
        {
            Vector3 movementDirection = new Vector3(_inputService.Axis.x, 0f, _inputService.Axis.y);

            if (movementDirection == Vector3.zero)
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }
    }
}
