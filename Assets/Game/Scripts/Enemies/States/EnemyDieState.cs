using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class EnemyDieState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _enemiesCollection;

        public void Init(IAllEnemiesCollection enemiesCollection)
        {
            _enemiesCollection = enemiesCollection;
        }

        public void Enter()
        {
            _enemiesCollection.RemoveFromCollection(gameObject);
            Destroy(gameObject);
        }

        public void Run()
        {
        }

        public void Exit()
        {
        }
    }
}
