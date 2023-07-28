using Game.Scripts.Projectiles;
using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerBow : PlayerWeapon
    {
        protected override void Fire(Vector3 targetPosition)
        {
            Projectile projectile =
                _gameObjectFactory.CreateProjectile(_projectilePrefab, _attackPoint.position);
            projectile.Init(targetPosition, _projectileSpeed, _attackPower);
            projectile.MoveToTarget();
        }
    }
}
