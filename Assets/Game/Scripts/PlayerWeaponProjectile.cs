using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerWeaponProjectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _attackPower;
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

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out Health health);

            if (health != null)
            {
                health.TakeDamage(_attackPower);
            }

            Destroy(gameObject);
        }
    }
}
