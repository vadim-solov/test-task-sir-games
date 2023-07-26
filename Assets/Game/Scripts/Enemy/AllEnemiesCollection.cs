using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class AllEnemiesCollection
    {
        private readonly List<Enemy> _allEnemies = new List<Enemy>();

        public void AddEnemyToList(Enemy enemy)
        {
            _allEnemies.Add(enemy);
        }

        public Enemy FindClosestEnemy(Vector3 position)
        {
            return _allEnemies.Count == 0
                ? null
                : _allEnemies.OrderBy(enemy => Vector3.Distance(position, enemy.transform.position)).FirstOrDefault();
        }
    }
}
