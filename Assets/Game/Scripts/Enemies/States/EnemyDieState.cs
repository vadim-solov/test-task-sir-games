using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.StateMachine;
using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class EnemyDieState : MonoBehaviour, IState
    {
        private Enemy _enemy;
        private IAllEnemiesCollection _enemiesCollection;

        public void Init(Enemy enemy, IAllEnemiesCollection enemiesCollection)
        {
            _enemy = enemy;
            _enemiesCollection = enemiesCollection;
        }

        public void Enter()
        {
            _enemiesCollection.RemoveFromCollection(_enemy);
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
