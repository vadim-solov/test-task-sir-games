using UnityEngine;

namespace Game.Scripts
{
    public abstract class Health : MonoBehaviour
    {
        private float _maxHP;
        private float _currentHP;

        protected abstract void Die();

        public void Init(float maxHP)
        {
            _maxHP = maxHP;
            _currentHP = _maxHP;
        }

        public void TakeDamage(float damage)
        {
            _currentHP -= damage;
            if (_currentHP <= 0)
            {
                Die();
            }
        }
    }
}
