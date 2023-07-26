using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Services.EnemiesCollection
{
    public class AllEnemiesCollection : IAllEnemiesCollection
    {
        private readonly List<Enemy.Enemy> _allEnemies = new List<Enemy.Enemy>();

        public void AddEnemyToList(Enemy.Enemy enemy)
        {
            _allEnemies.Add(enemy);
        }

        public Enemy.Enemy FindClosestEnemy(Vector3 position)
        {
            return _allEnemies.Count == 0
                ? null
                : _allEnemies.OrderBy(enemy => Vector3.Distance(position, enemy.transform.position)).FirstOrDefault();
        }
    }
}
