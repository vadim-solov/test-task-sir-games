using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Input;
using Game.Scripts.Services.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(IStateMachine))]
    [RequireComponent(typeof(PlayerMovementState))]
    [RequireComponent(typeof(CurrentPlayerWeapon))]
    public class PlayerAttackState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _allEnemiesCollection;
        private CurrentPlayerWeapon _currentPlayerWeapon;
        private IStateMachine _stateMachine;
        private PlayerMovementState _movementState;

        private const float RotationSpeed = 10f;

        public void Init(IAllEnemiesCollection allEnemiesCollection)
        {
            _allEnemiesCollection = allEnemiesCollection;
            _currentPlayerWeapon = GetComponent<CurrentPlayerWeapon>();
            _stateMachine = GetComponent<IStateMachine>();
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
            if (!InputService.IsMove() && !_allEnemiesCollection.IsCollectionEmpty)
            {
                GameObject closestEnemy = _allEnemiesCollection.FindClosestEnemy(transform.position);
                TurnToClosestEnemy(closestEnemy.transform.position);
                _currentPlayerWeapon.CurrentWeapon.FireIfReloaded(closestEnemy.transform.position);
            }
            else
            {
                _stateMachine.ChangeStateIfNewStateDifferent(_movementState);
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
