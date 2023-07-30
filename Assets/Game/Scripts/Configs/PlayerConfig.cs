using System;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [Serializable]
    public class PlayerConfig
    {
        [SerializeField]
        private GameObject _playerPrefab;
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _maxHP;
        [SerializeField]
        private float _ProjectileSpeed;
        [SerializeField]
        private float _attackPower;
        [SerializeField]
        private float _weaponReloadTime;

        public GameObject PlayerPrefab => _playerPrefab;
        public float MovementSpeed => _movementSpeed;
        public float MaxHP => _maxHP;
        public float ProjectileSpeed => _ProjectileSpeed;
        public float AttackPower => _attackPower;
        public float WeaponReloadTime => _weaponReloadTime;
    }
}
