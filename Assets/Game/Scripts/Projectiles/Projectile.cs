using UnityEngine;

namespace Game.Scripts.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        protected float _attackPower;
        private Vector3 _targetPosition;
        private float _projectileSpeed;

        private const float HeightProjectileFly = 2f;

        public void Init(Vector3 targetPosition, float projectileSpeed, float attackPower)
        {
            _projectileSpeed = projectileSpeed;
            _targetPosition = targetPosition;
            _attackPower = attackPower;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            FixHeightProjectileFly();
        }

        public void MoveToTarget()
        {
            Vector3 direction = (_targetPosition - transform.position).normalized;
            _rigidbody.velocity = direction * _projectileSpeed;
        }

        private void FixHeightProjectileFly()
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y = HeightProjectileFly;
            transform.position = currentPosition;
        }
    }
}
