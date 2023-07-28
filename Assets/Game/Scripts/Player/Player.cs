using Game.Scripts.Configs;
using Game.Scripts.Player.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Input;
using UnityEngine;

namespace Game.Scripts.Player
{
    [RequireComponent(typeof(Health))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private PlayerIdleState _idleState;
        [SerializeField]
        private PlayerAttackState _attacState;
        [SerializeField]
        private PlayerMovementState _movementState;

        private IInputService _inputService;
        private StateMachine.StateMachine _stateMachine;
        private Health _health;

        public void Init(IInputService inputService, IAllEnemiesCollection allEnemiesCollection, GameConfig gameConfig)
        {
            _health = GetComponent<Health>();
            _health.Init(gameConfig.PlayerConfig.MaxHP);
            _inputService = inputService;
            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.Init(_idleState);
            _attacState.Init(allEnemiesCollection);
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
