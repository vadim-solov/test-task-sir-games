using Game.Scripts.Enemies;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using Game.Scripts.StateMachine;

namespace Game.Scripts.App.States
{
    public class GameplayState : IState
    {
        private readonly IPlayerGameObject _playerGameObject;
        private readonly IAllEnemiesCollection _allEnemiesCollection;
        private readonly CoinSpawner _coinSpawner;

        public GameplayState(IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection,
            CoinSpawner coinSpawner)
        {
            _playerGameObject = playerGameObject;
            _allEnemiesCollection = allEnemiesCollection;
            _coinSpawner = coinSpawner;
        }

        public void Enter()
        {
            ActivatePlayer();
            ActivateEnemies();
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

        private void ActivatePlayer()
        {
            _playerGameObject.Instance.SetAttackState();
        }

        private void ActivateEnemies()
        {
            foreach (Enemy enemy in _allEnemiesCollection.AllEnemies)
            {
                enemy.SetMovementState();
            }
        }

        private void OnEnemyRemoved(Enemy enemy)
        {
            _coinSpawner.CreateAndAddToCollection(enemy.transform.position);
        }

        private void OnEnemiesCollectionIsEmpty()
        {
            _coinSpawner.SummonAllCoinsToPosition(_playerGameObject.Instance.transform.position);
        }
    }
}
