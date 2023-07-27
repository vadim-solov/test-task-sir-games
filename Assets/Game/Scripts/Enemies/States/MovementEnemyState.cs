using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts.Enemies.States
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementEnemyState : MonoBehaviour, IState
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
            _navMeshAgent.Move(_target.Instance.transform.position);
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
