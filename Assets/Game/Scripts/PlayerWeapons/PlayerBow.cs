using Game.Scripts.Projectiles;
using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerBow : PlayerWeapon
    {
        protected override void Fire(Transform targetTransform)
        {
            Projectile projectile =
                _gameObjectFactory.CreateProjectile(_projectilePrefab, _attackPoint.position);
            projectile.Init(targetTransform, _projectileSpeed, _attackPower);
            projectile.MoveToTarget();
        }
    }
}
