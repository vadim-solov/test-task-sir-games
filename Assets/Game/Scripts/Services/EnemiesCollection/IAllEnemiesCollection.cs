using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public interface IAllEnemiesCollection
    {
        public void AddEnemyToList(Enemy enemy);
        public Enemy FindClosestEnemy(Vector3 position);
    }
}
