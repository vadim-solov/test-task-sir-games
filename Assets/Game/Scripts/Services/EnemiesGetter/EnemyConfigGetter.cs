using System.Linq;
using Game.Scripts.Configs;
using Game.Scripts.Enemies;

namespace Game.Scripts.Services.EnemiesGetter
{
    public class EnemyConfigGetter : IEnemyConfigGetter
    {
        private readonly GameConfig _gameConfig;

        public EnemyConfigGetter(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public EnemyConfig GetEnemyConfigByType(EnemyType enemyType)
        {
            return _gameConfig.EnemiesConfig
                .Where(enemyConfig => enemyConfig.EnemyType == enemyType)
                .Select(enemyConfig => enemyConfig).FirstOrDefault();
        }
    }
}
