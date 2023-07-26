using UnityEngine;

namespace Game.Scripts.SpawnPoint
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private Enemy.Enemy _enemyPrefab;

        public Enemy.Enemy EnemyPrefab => _enemyPrefab;
    }
}
