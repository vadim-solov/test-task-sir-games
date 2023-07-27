using Game.Scripts.Configs;
using Game.Scripts.Enemies;

namespace Game.Scripts.Services.EnemiesGetter
{
    public interface IEnemyConfigGetter
    {
        public EnemyConfig GetEnemyConfigByType(EnemyType enemyType);
    }
}
