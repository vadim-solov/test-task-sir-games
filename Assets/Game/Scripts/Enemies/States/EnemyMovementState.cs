using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public abstract class EnemyMovementState : MonoBehaviour, IState
    {
        protected IPlayerGameObject _target;
        protected float _movementSpeed;

        public abstract void Enter();
        public abstract void Run();
        public abstract void Exit();

        public void Init(IPlayerGameObject target, float movementSpeed)
        {
            _target = target;
            _movementSpeed = movementSpeed;
        }

        protected void RotateToTarget()
        {
            transform.LookAt(_target.Instance.transform);
        }
    }
}
