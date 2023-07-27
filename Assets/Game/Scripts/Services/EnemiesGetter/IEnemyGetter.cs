using Game.Scripts.Enemy;

namespace Game.Scripts.Services.EnemiesGetter
{
    public interface IEnemyGetter
    {
        public Enemy.Enemy GetEnemyByType(EnemyType enemyType);
    }
}
