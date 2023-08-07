using Game.Scripts.Services.AppStateMachine;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(MonoBehaviourStateMachine))]
    [RequireComponent(typeof(PlayerMovementState))]
    [RequireComponent(typeof(CurrentPlayerWeapon))]
    public class PlayerAttackState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _allEnemiesCollection;
        private CurrentPlayerWeapon _currentPlayerWeapon;
        private MonoBehaviourStateMachine _monoBehaviourStateMachine;
        private PlayerMovementState _movementState;
        private IInputService _inputService;

        private const float RotationSpeed = 10f;

        [Inject]
        private void Construct(IInputService inputService, IAllEnemiesCollection allEnemiesCollection)
        {
            _inputService = inputService;
            _allEnemiesCollection = allEnemiesCollection;
        }

        public void Awake()
        {
            _currentPlayerWeapon = GetComponent<CurrentPlayerWeapon>();
            _monoBehaviourStateMachine = GetComponent<MonoBehaviourStateMachine>();
            _movementState = GetComponent<PlayerMovementState>();
        }

        public void Enter()
        {
        }

        public void Run()
        {
            AttackClosestEnemyOrChangeState();
        }

        public void Exit()
        {
        }

        private void AttackClosestEnemyOrChangeState()
        {
            if (!_inputService.IsMove() && !_allEnemiesCollection.IsCollectionEmpty)
            {
                GameObject closestEnemy = _allEnemiesCollection.FindClosestEnemy(transform.position);
                TurnToClosestEnemy(closestEnemy.transform.position);
                _currentPlayerWeapon.CurrentWeapon.FireIfReloaded(closestEnemy.transform.position);
            }
            else
            {
                _monoBehaviourStateMachine.ChangeStateIfNewStateDifferent(_movementState);
            }
        }

        private void TurnToClosestEnemy(Vector3 enemyPosition)
        {
            Vector3 directionToTarget = enemyPosition - transform.position;
            directionToTarget.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }
}
