using Game.Scripts.Enemies.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    public class SpiderEnemy : Enemy
    {
        [SerializeField]
        private EnemyGroundMovementState _groundMovementState;

        public override void Init(IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject)
        {
            base.Init(allEnemiesCollection, playerGameObject);
            _groundMovementState.Init(playerGameObject);
            _stateMachine.ChangeStateIfNewStateDifferent(_groundMovementState);
        }
    }
}
