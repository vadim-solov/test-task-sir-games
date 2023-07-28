using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Projectiles
{
    public class PlayerProjectile : Projectile
    {
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out Enemy enemy);

            if (enemy != null)
            {
                Health health = enemy.GetComponent<Health>();
                health.TakeDamage(_attackPower);
            }

            Destroy(gameObject);
        }
    }
}
