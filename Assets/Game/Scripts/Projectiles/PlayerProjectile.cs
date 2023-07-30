using Game.Scripts.Enemies;
using UnityEngine;

namespace Game.Scripts.Projectiles
{
    public class PlayerProjectile : Projectile
    {
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out EnemyHealth enemyHealth);

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_attackPower);
            }

            Destroy(gameObject);
        }
    }
}
