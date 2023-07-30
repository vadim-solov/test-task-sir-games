using System;
using Game.Scripts.Enemies;
using Game.Scripts.Projectiles;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField]
        private EnemyType _enemyType;
        [SerializeField]
        private GameObject _enemyPrefab;
        [SerializeField]
        private Projectile _projectilePrefab;
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _maxHP;
        [SerializeField]
        private float _stoppingDistance;
        [SerializeField]
        private float _waitingTimeAfterAttack;
        [SerializeField]
        private float _projectileSpeed;
        [SerializeField]
        private float _attackPower;

        public EnemyType EnemyType => _enemyType;
        public GameObject EnemyPrefab => _enemyPrefab;
        public Projectile ProjectilePrefab => _projectilePrefab;
        public float MovementSpeed => _movementSpeed;
        public float MaxHP => _maxHP;
        public float StoppingDistance => _stoppingDistance;
        public float WaitingTimeAfterAttack => _waitingTimeAfterAttack;
        public float ProjectileSpeed => _projectileSpeed;
        public float AttackPower => _attackPower;
    }
}
