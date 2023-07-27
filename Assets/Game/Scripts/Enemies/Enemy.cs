using Game.Scripts.Enemies.States;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        private StateMachine.StateMachine _stateMachine;
        private EnemyIdleState _idleState;

        public void Init()
        {
            _idleState = new EnemyIdleState();
            _stateMachine = new StateMachine.StateMachine();
            _stateMachine.Init(_idleState);
        }
    }
}
