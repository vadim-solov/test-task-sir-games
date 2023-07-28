using Game.Scripts.Configs;
using Game.Scripts.Projectiles;
using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public abstract class PlayerWeapon : MonoBehaviour
    {
        [SerializeField]
        protected Projectile _projectilePrefab;
        [SerializeField]
        protected Transform _attackPoint;

        private protected float _attackSpeed;
        protected float _attackPower;
        protected GameObjectFactory _gameObjectFactory;

        private float _timer;
        private float _reloadTime;

        public void Init(GameObjectFactory gameObjectFactory, GameConfig gameConfig)
        {
            _gameObjectFactory = gameObjectFactory;
            _attackPower = gameConfig.PlayerConfig.AttackPower;
            _attackSpeed = gameConfig.PlayerConfig.AttackSpeed;
            _reloadTime = gameConfig.PlayerConfig.WeaponReloadTime;
        }

        protected abstract void Fire(Transform targetTransform);

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void FireIfReloaded(Transform targetTransform)
        {
            if (_timer >= _reloadTime)
            {
                Fire(targetTransform);
                _timer = 0f;
            }
        }
    }
}
