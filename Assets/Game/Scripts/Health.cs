using UnityEngine;

namespace Game.Scripts
{
    public class Health : MonoBehaviour
    {
        private float _maxHP;
        private float _currentHP;

        public void Init(float maxHP)
        {
            _maxHP = maxHP;
        }

        public void TakeDamage(float damage)
        {
            _maxHP -= damage;
            Debug.Log(_maxHP);
        }
    }
}
