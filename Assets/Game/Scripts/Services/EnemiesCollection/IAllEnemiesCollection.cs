using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public interface IAllEnemiesCollection
    {
        public void AddEnemyToList(Enemy.Enemy enemy);
        public Enemy.Enemy FindClosestEnemy(Vector3 position);
    }
}
