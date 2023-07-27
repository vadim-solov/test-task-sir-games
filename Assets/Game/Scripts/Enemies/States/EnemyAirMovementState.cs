using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class EnemyAirMovementState : MonoBehaviour, IState
    {
        private IPlayerGameObject _target;

        public void Init(IPlayerGameObject target)
        {
            _target = target;
        }

        public void Enter()
        {
        }

        public void Run()
        {
            MoveToTarget();
            RotateToTarget();
        }

        public void Exit()
        {
        }

        private void MoveToTarget()
        {
            Vector3 directionToPlayer = _target.Instance.transform.position - transform.position;
            directionToPlayer.y = 0f;
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * 1f * Time.deltaTime;
        }

        private void RotateToTarget()
        {
            transform.LookAt(_target.Instance.transform);
        }
    }
}
