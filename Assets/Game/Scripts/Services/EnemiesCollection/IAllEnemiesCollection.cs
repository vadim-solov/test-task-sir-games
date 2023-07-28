using System.Collections.Generic;
using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public interface IAllEnemiesCollection
    {
        public List<Enemy> AllEnemies { get; }

        public void AddEnemyToCollection(Enemy enemy);
        public void RemoveFromCollection(Enemy enemy);
        public Enemy FindClosestEnemy(Vector3 position);
    }
}
