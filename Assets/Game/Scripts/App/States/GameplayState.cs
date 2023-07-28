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
        private readonly GameObjectFactory _gameObjectFactory;

        public GameplayState(IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection,
            GameObjectFactory gameObjectFactory)
        {
            _playerGameObject = playerGameObject;
            _allEnemiesCollection = allEnemiesCollection;
            _gameObjectFactory = gameObjectFactory;
        }

        public void Enter()
        {
            ActivatePlayer();
            ActivateEnemies();
            _allEnemiesCollection.EnemyRemoved += OnEnemyRemoved;
        }

        public void Run()
        {
        }

        public void Exit()
        {
            _allEnemiesCollection.EnemyRemoved -= OnEnemyRemoved;
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
            _gameObjectFactory.CreateCoin(enemy.transform.position);
        }
    }
}
