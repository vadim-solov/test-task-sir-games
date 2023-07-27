using System.Linq;
using Game.Scripts.Configs;
using Game.Scripts.Enemy;

namespace Game.Scripts.Services.EnemiesGetter
{
    public class EnemyGetter : IEnemyGetter
    {
        private readonly GameConfig _gameConfig;

        public EnemyGetter(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public Enemy.Enemy GetEnemyByType(EnemyType enemyType)
        {
            return _gameConfig.EnemiesConfig
                .Where(enemyConfig => enemyConfig.EnemyType == enemyType)
                .Select(enemyConfig => enemyConfig.EnemyPrefab).FirstOrDefault();
        }
    }
}
