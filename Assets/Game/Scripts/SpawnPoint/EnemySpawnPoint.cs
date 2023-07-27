using Game.Scripts.Enemy;
using UnityEngine;

namespace Game.Scripts.SpawnPoint
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;
    }
}
