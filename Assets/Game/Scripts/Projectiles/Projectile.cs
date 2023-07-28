using UnityEngine;

namespace Game.Scripts.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        protected float _attackPower;
        private Transform _targetTransform;
        private float _projectileSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(Transform targetTransform, float projectileSpeed, float attackPower)
        {
            _projectileSpeed = projectileSpeed;
            _targetTransform = targetTransform;
            _attackPower = attackPower;
        }

        public void MoveToTarget()
        {
            Vector3 direction = (_targetTransform.position - transform.position).normalized;
            _rigidbody.velocity = direction * _projectileSpeed;
        }
    }
}
