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
        [SerializeField]
        private float _stoppingDistance;
        [SerializeField]
        private float _attackReloadTime;
        [SerializeField]
        private float _waitingTimeAfterAttack;

        public EnemyType EnemyType => _enemyType;
        public Enemy EnemyPrefab => _enemyPrefab;
        public float MovementSpeed => _movementSpeed;
        public float MaxHP => _maxHP;
        public float StoppingDistance => _stoppingDistance;
        public float AttackReloadTime => _attackReloadTime;
        public float WaitingTimeAfterAttack => _waitingTimeAfterAttack;
    }
}
