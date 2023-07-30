using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.Input;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(MonoBehaviourStateMachine))]
    [RequireComponent(typeof(PlayerMovementState))]
    [RequireComponent(typeof(CurrentPlayerWeapon))]
    public class PlayerAttackState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _allEnemiesCollection;
        private CurrentPlayerWeapon _currentPlayerWeapon;
        private MonoBehaviourStateMachine _stateMachine;
        private PlayerMovementState _movementState;

        private const float RotationSpeed = 10f;

        public void Init(IAllEnemiesCollection allEnemiesCollection)
        {
            _allEnemiesCollection = allEnemiesCollection;
            _currentPlayerWeapon = GetComponent<CurrentPlayerWeapon>();
            _stateMachine = GetComponent<MonoBehaviourStateMachine>();
            _movementState = GetComponent<PlayerMovementState>();
        }

        public void Enter()
        {
        }

        public void Run()
        {
            ChangeStateIfMove();
            GameObject closestEnemy = _allEnemiesCollection.FindClosestEnemy(transform.position);

            if (closestEnemy == null)
            {
                return;
            }

            TurnToClosestEnemy(closestEnemy.transform.position);
            _currentPlayerWeapon.CurrentWeapon.FireIfReloaded(closestEnemy.transform.position);
        }

        public void Exit()
        {
        }

        private void ChangeStateIfMove()
        {
            if (InputService.IsMove())
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
