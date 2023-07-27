using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public class AllEnemiesCollection : IAllEnemiesCollection
    {
        private readonly List<Enemy> _allEnemies = new List<Enemy>();

        public void AddEnemyToCollection(Enemy enemy)
        {
            _allEnemies.Add(enemy);
        }

        public void RemoveFromCollection(Enemy enemy)
        {
            _allEnemies.Remove(enemy);
        }

        public Enemy FindClosestEnemy(Vector3 position)
        {
            return _allEnemies.Count == 0
                ? null
                : _allEnemies.OrderBy(enemy => Vector3.Distance(position, enemy.transform.position)).FirstOrDefault();
        }
    }
}
