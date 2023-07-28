using System;
using UnityEngine;

namespace Game.Scripts
{
    public class Health : MonoBehaviour
    {
        private float _maxHP;
        private float _currentHP;

        public event Action Die;

        public void Init(float maxHP)
        {
            _maxHP = maxHP;
            _currentHP = _maxHP;
        }

        public void TakeDamage(float damage)
        {
            _currentHP -= damage;
            Debug.Log(_currentHP);
            if (_currentHP <= 0)
            {
                Die?.Invoke();
            }
        }
    }
}
