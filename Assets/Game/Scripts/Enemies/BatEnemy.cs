using Game.Scripts.Enemies.States;
using Game.Scripts.Services.EnemiesCollection;
using Game.Scripts.Services.PlayerInstance;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    public class BatEnemy : Enemy
    {
        [SerializeField]
        private EnemyAirMovementState _airMovementState;

        public override void Init(IAllEnemiesCollection allEnemiesCollection, IPlayerGameObject playerGameObject)
        {
            base.Init(allEnemiesCollection, playerGameObject);
            _airMovementState.Init(playerGameObject);
            _stateMachine.ChangeStateIfNewStateDifferent(_airMovementState);
        }
    }
}
