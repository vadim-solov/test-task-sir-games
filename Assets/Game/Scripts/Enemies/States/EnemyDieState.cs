using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.GameStateMachine;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.States
{
    public class EnemyDieState : MonoBehaviour, IState
    {
        private IAllEnemiesCollection _enemiesCollection;

        [Inject]
        public void Construct(IAllEnemiesCollection enemiesCollection)
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
