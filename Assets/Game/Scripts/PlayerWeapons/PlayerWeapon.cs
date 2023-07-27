using Game.Scripts.Configs;
using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public abstract class PlayerWeapon : MonoBehaviour
    {
        [SerializeField]
        protected PlayerWeaponProjectile _projectilePrefab;
        [SerializeField]
        protected Transform _attackPoint;

        private protected float _attackSpeed;
        protected float _attackPower;
        protected GameObjectFactory _gameObjectFactory;

        private float _timer;
        private const float ReloadTime = 0.5f;

        public void Init(GameObjectFactory gameObjectFactory, GameConfig gameConfig)
        {
            _gameObjectFactory = gameObjectFactory;
            _attackPower = gameConfig.PlayerConfig.AttackPower;
            _attackSpeed = gameConfig.PlayerConfig.AttackSpeed;
        }

        protected abstract void Fire(Transform targetTransform);

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void FireIfReloaded(Transform targetTransform)
        {
            if (_timer >= ReloadTime)
            {
                Fire(targetTransform);
                _timer = 0f;
            }
        }
    }
}
