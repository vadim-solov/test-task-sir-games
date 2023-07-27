using System.Linq;
using Game.Scripts.Configs;
using Game.Scripts.Enemies;

namespace Game.Scripts.Services.EnemiesGetter
{
    public class EnemyGetter : IEnemyGetter
    {
        private readonly GameConfig _gameConfig;

        public EnemyGetter(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public Enemy GetEnemyByType(EnemyType enemyType)
        {
            return _gameConfig.EnemiesConfig
                .Where(enemyConfig => enemyConfig.EnemyType == enemyType)
                .Select(enemyConfig => enemyConfig.EnemyPrefab).FirstOrDefault();
        }
    }
}
