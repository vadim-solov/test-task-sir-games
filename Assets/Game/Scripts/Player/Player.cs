using Game.Scripts.Configs;
using Game.Scripts.Player.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerIdleState _idleState;
        [SerializeField]
        private PlayerAttackState _attacState;
        [SerializeField]
        private PlayerMovementState _movementState;
        [SerializeField]
        private Transform _weaponPoint;

        private IInputService _inputService;
        private StateMachine.StateMachine _stateMachine;

        public Transform WeaponPoint => _weaponPoint;

        public void Init(IInputService inputService, IAllEnemiesCollection allEnemiesCollection, GameConfig gameConfig)
        {
            _inputService = inputService;
            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.Init(_idleState);
            _attacState.Init(allEnemiesCollection, gameConfig);
            _movementState.Init(gameConfig);
        }

        private void Update()
        {
            TryChangeState();
            _stateMachine.CurrentState.Run();
        }

        public void SetAttackState()
        {
            _stateMachine.ChangeStateIfNewStateDifferent(_attacState);
        }

        private void TryChangeState()
        {
            if (_stateMachine.CurrentState.GetType() == typeof(PlayerIdleState))
            {
                return;
            }

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
