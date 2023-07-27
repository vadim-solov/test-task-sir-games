using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public abstract class EnemyMovementState : MonoBehaviour, IState
    {
        protected IPlayerGameObject _target;

        public abstract void Enter();
        public abstract void Run();
        public abstract void Exit();

        public void Init(IPlayerGameObject target)
        {
            _target = target;
        }

        protected void RotateToTarget()
        {
            transform.LookAt(_target.Instance.transform);
        }
    }
}
