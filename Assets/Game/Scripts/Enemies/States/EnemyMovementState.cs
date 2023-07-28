using System;
using Game.Scripts.Configs;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public abstract class EnemyMovementState : MonoBehaviour, IState
    {
        protected IPlayerGameObject _playerGameObject;
        protected float _movementSpeed;
        protected float _stoppingDistance;

        private const float RotationSpeed = 10f;

        public event Action StoppingDistanceAchieved;

        public abstract void Enter();
        public abstract void Run();
        public abstract void Exit();

        public void Init(IPlayerGameObject playerGameObject, EnemyConfig enemyConfig)
        {
            _playerGameObject = playerGameObject;
            _movementSpeed = enemyConfig.MovementSpeed;
            _stoppingDistance = enemyConfig.StoppingDistance;
        }

        protected void RotateToTarget()
        {
            Vector3 directionToTarget = _playerGameObject.Instance.transform.position - transform.position;
            directionToTarget.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
        }

        protected void CheckStoppingDistance()
        {
            float distance = Vector3.Distance(_playerGameObject.Instance.transform.position, transform.position);

            if (_stoppingDistance >= distance)
            {
                StoppingDistanceAchieved?.Invoke();
            }
        }
    }
}
