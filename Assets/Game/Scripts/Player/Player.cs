using Game.Scripts.Player.States;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerIdleState _idleState;
        [SerializeField]
        private PlayerAttackState _attackState;
        [SerializeField]
        private PlayerMovementState _movementState;

        private IInputService _inputService;
        private StateMachine _stateMachine;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
            _stateMachine = new StateMachine();
            _stateMachine.Init(_idleState);
        }

        private void Update()
        {
            TryChangeState();
            _stateMachine.CurrentState.Run();
        }

        private void TryChangeState()
        {
            if (IsMove())
            {
                _stateMachine.ChangeStateIfNewStateDifferent(_movementState);
            }
            else
            {
                _stateMachine.ChangeStateIfNewStateDifferent(_attackState);
            }
        }

        private bool IsMove()
        {
            return _inputService.Axis != Vector3.zero;
        }
    }
}
