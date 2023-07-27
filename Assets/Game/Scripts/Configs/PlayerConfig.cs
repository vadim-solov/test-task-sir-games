using System;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [Serializable]
    public class PlayerConfig
    {
        [SerializeField]
        private Player.Player _playerPrefab;
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _maxHP;
        [SerializeField]
        private float _attackSpeed;
        [SerializeField]
        private float _attackPower;

        public Player.Player PlayerPrefab => _playerPrefab;
        public float MovementSpeed => _movementSpeed;
        public float MaxHP => _maxHP;
        public float AttackSpeed => _attackSpeed;
        public float AttackPower => _attackPower;
    }
}
