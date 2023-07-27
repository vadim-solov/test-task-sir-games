using Game.Scripts.Enemies;

namespace Game.Scripts.Services.EnemiesGetter
{
    public interface IEnemyGetter
    {
        public Enemy GetEnemyByType(EnemyType enemyType);
    }
}
