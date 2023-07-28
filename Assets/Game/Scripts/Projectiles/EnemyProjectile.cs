using UnityEngine;

namespace Game.Scripts.Projectiles
{
    public class EnemyProjectile : Projectile
    {
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out Player.Player player);

            if (player != null)
            {
                Health health = player.GetComponent<Health>();
                health.TakeDamage(_attackPower);
            }

            Destroy(gameObject);
        }
    }
}
