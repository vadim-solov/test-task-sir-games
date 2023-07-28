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

        public GameplayState(IPlayerGameObject playerGameObject, IAllEnemiesCollection allEnemiesCollection)
        {
            _playerGameObject = playerGameObject;
            _allEnemiesCollection = allEnemiesCollection;
        }

        public void Enter()
        {
            ActivatePlayer();
            ActivateEnemies();
        }

        public void Run()
        {
        }

        public void Exit()
        {
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
    }
}
