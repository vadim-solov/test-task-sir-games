using Game.Scripts.Player;
using UnityEngine;

namespace Game.Scripts.Projectiles
{
    public class EnemyProjectile : Projectile
    {
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerHealth playerHealth);

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(_attackPower);
            }

            Destroy(gameObject);
        }
    }
}
