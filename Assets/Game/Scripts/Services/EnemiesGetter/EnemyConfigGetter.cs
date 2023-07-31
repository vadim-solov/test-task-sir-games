using System.Linq;
using Game.Scripts.Configs;
using Game.Scripts.Enemies;
using Game.Scripts.Services.GameDataProvider;

namespace Game.Scripts.Services.EnemiesGetter
{
    public class EnemyConfigGetter : IEnemyConfigGetter
    {
        private readonly IGameConfigDataProvider _gameConfig;

        public EnemyConfigGetter(IGameConfigDataProvider gameConfig)
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
