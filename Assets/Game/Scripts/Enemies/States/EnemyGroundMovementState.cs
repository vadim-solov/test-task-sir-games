using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Enemies.States
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyGroundMovementState : EnemyMovementState
    {
        private NavMeshAgent _navMeshAgent;

        public void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
        }

        public override void Run()
        {
            MoveToTarget();
            RotateToTarget();
        }

        public override void Exit()
        {
        }

        private void MoveToTarget()
        {
            _navMeshAgent.SetDestination(_target.Instance.transform.position);
        }
    }
}
