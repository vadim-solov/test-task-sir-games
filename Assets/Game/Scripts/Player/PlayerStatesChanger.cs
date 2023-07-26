using Game.Scripts.Player.States;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerStatesChanger : MonoBehaviour
    {
        [SerializeField]
        private PlayerIdleState _idleState;
        [SerializeField]
        private PlayerAttackState _attacState;
        [SerializeField]
        private PlayerMovementState _movementState;

        private IInputService _inputService;
        private StateMachine.StateMachine _stateMachine;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
            _stateMachine = new StateMachine.StateMachine();
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
                _stateMachine.ChangeStateIfNewStateDifferent(_attacState);
            }
        }

        private bool IsMove()
        {
            return _inputService.Axis != Vector3.zero;
        }
    }
}
