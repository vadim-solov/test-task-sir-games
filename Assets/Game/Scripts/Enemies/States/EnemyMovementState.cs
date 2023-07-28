using System;
using Game.Scripts.Configs;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public abstract class EnemyMovementState : MonoBehaviour, IState
    {
        protected IPlayerGameObject _target;
        protected float _movementSpeed;
        protected float _stoppingDistance;

        public event Action StoppingDistanceAchieved;

        public abstract void Enter();
        public abstract void Run();
        public abstract void Exit();

        public void Init(IPlayerGameObject target, EnemyConfig enemyConfig)
        {
            _target = target;
            _movementSpeed = enemyConfig.MovementSpeed;
            _stoppingDistance = enemyConfig.StoppingDistance;
        }

        protected void RotateToTarget()
        {
            transform.LookAt(_target.Instance.transform);
        }

        protected void CheckStoppingDistance()
        {
            float distance = Vector3.Distance(_target.Instance.transform.position, transform.position);

            if (_stoppingDistance >= distance)
            {
                StoppingDistanceAchieved?.Invoke();
            }
        }
    }
}
