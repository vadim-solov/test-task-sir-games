using Game.Scripts.Enemies.States;
using Game.Scripts.Player.States;
using Game.Scripts.Services.AppStateMachine;
using Game.Scripts.Services.CoinsSpawners;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.App.States
{
    public class GameplayState : IState
    {
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly ICoinSpawner _coinSpawner;

        public GameplayState(IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection,
            ICoinSpawner coinSpawner)
        {
            _playerGameObject = playerGameObject;
            _allEnemiesCollection = allEnemiesCollection;
            _coinSpawner = coinSpawner;
        }

        public void Enter()
        {
            SetMovementStateForPlayer();
            SetMovementStateForAllEnemies();
            _allEnemiesCollection.EnemyRemoved += OnEnemyRemoved;
            _allEnemiesCollection.CollectionIsEmpty += OnEnemiesCollectionIsEmpty;
        }

        public void Run()
        {
        }

        public void Exit()
        {
            _allEnemiesCollection.EnemyRemoved -= OnEnemyRemoved;
            _allEnemiesCollection.CollectionIsEmpty -= OnEnemiesCollectionIsEmpty;
        }

        private void SetMovementStateForPlayer()
        {
            MonoBehaviourStateMachine monoBehaviourStateMachine =
                _playerGameObject.Instance.GetComponent<MonoBehaviourStateMachine>();
            monoBehaviourStateMachine.ChangeState<PlayerMovementState>();
        }

        private void SetMovementStateForAllEnemies()
        {
            foreach (GameObject enemy in _allEnemiesCollection.AllEnemies)
            {
                MonoBehaviourStateMachine monoBehaviourStateMachine = enemy.GetComponent<MonoBehaviourStateMachine>();
                monoBehaviourStateMachine.ChangeState<EnemyMovementState>();
            }
        }

        private void OnEnemyRemoved(GameObject enemy)
        {
            _coinSpawner.CreateAndAddToCollection(enemy.transform.position);
        }

        private void OnEnemiesCollectionIsEmpty()
        {
            _coinSpawner.SummonAllCoinsToPosition(_playerGameObject.Instance.transform.position);
        }
    }
}
