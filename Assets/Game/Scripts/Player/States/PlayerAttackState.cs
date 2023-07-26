using Game.Scripts.Configs;
using Game.Scripts.PlayerWeapons;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Player.States
{
    public class PlayerAttackState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _allEnemiesCollection;
        private PlayerWeapon _playerWeapon;

        public void Init(IAllEnemiesCollection allEnemiesCollection, GameConfig gameConfig)
        {
            _allEnemiesCollection = allEnemiesCollection;
            _playerWeapon = gameConfig.PlayerWeaponsPrefabs[0];
        }

        public void Enter()
        {
            Debug.Log("enter in attack state");
        }

        public void Run()
        {
            TurnToClosestEnemy();
            _playerWeapon.Fire();
        }

        public void Exit()
        {
            Debug.Log("exit on attack state");
        }

        private void TurnToClosestEnemy()
        {
            Enemy.Enemy closestEnemy = _allEnemiesCollection.FindClosestEnemy(transform.position);
            Vector3 directionToTarget = closestEnemy.transform.position - transform.position;
            directionToTarget.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
    }
}
