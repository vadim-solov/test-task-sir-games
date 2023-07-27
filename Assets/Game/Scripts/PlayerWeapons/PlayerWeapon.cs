using Game.Scripts.Configs;
using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public abstract class PlayerWeapon : MonoBehaviour
    {
        private float _attackPower;
        private float _attackSpeed;
        private float _timer;

        private const float ReloadTime = 0.5f;

        public void Init(GameConfig gameConfig)
        {
            _attackPower = gameConfig.PlayerConfig.AttackPower;
            _attackSpeed = gameConfig.PlayerConfig.AttackSpeed;
        }

        protected abstract void Fire();

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public void FireIfReloaded()
        {
            _timer += Time.deltaTime;

            if (_timer >= ReloadTime)
            {
                Fire();
                _timer = 0f;
            }
        }
    }
}
