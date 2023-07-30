using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    [RequireComponent(typeof(CurrentPlayerWeapon))]
    public class PlayerAttackState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _allEnemiesCollection;
        private CurrentPlayerWeapon _currentPlayerWeapon;

        private const float RotationSpeed = 10f;

        private void Awake()
        {
            _currentPlayerWeapon = GetComponent<CurrentPlayerWeapon>();
        }

        public void Init(IAllEnemiesCollection allEnemiesCollection)
        {
            _allEnemiesCollection = allEnemiesCollection;
        }

        public void Enter()
        {
        }

        public void Run()
        {
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

        private void TurnToClosestEnemy(Vector3 enemyPosition)
        {
            Vector3 directionToTarget = enemyPosition - transform.position;
            directionToTarget.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }
    }
}
