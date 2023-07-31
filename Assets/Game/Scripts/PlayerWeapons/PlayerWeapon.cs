using Game.Scripts.Configs;
using Game.Scripts.Projectiles;
using Game.Scripts.Services.Factory;
using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public abstract class PlayerWeapon : MonoBehaviour
    {
        [SerializeField]
        protected Projectile _projectilePrefab;
        [SerializeField]
        protected Transform _attackPoint;

        private protected float _projectileSpeed;
        protected float _attackPower;
        protected IGameObjectFactory _gameObjectFactory;

        private float _timer;
        private float _reloadTime;

        public void Init(IGameObjectFactory gameObjectFactory, GameConfig gameConfig)
        {
            _gameObjectFactory = gameObjectFactory;
            _attackPower = gameConfig.PlayerConfig.AttackPower;
            _projectileSpeed = gameConfig.PlayerConfig.ProjectileSpeed;
            _reloadTime = gameConfig.PlayerConfig.WeaponReloadTime;
        }

        protected abstract void Fire(Vector3 targetPosition);

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void FireIfReloaded(Vector3 targetPosition)
        {
            if (_timer >= _reloadTime)
            {
                Fire(targetPosition);
                _timer = 0f;
            }
        }
    }
}
