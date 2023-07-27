using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Enemies.States
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyGroundMovementState : MonoBehaviour, IState
    {
        private IPlayerGameObject _target;
        private NavMeshAgent _navMeshAgent;

        public void Init(IPlayerGameObject target)
        {
            _target = target;
            _navMeshAgent = GetComponent<NavMeshAgent>();
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
            _navMeshAgent.SetDestination(_target.Instance.transform.position);
        }

        private void RotateToTarget()
        {
            transform.LookAt(_target.Instance.transform);
        }
    }
}
