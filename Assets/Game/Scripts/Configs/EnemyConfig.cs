using System;
using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField]
        private EnemyType _enemyType;
        [SerializeField]
        private Enemy _enemyPrefab;
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _maxHP;

        public EnemyType EnemyType => _enemyType;
        public Enemy EnemyPrefab => _enemyPrefab;
        public float MovementSpeed => _movementSpeed;
        public float MaxHP => _maxHP;
    }
}
