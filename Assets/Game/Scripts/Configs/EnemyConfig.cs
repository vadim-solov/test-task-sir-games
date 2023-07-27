using System;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [Serializable]
    public class EnemyConfig
    {
        [SerializeField]
        private Enemy.Enemy _enemyPrefab;
        [SerializeField]
        private float _movementSpeed;
    }
}
