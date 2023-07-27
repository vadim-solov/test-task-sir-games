using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerBow : PlayerWeapon
    {
        protected override void Fire(Transform targetTransform)
        {
            PlayerWeaponProjectile projectile =
                _gameObjectFactory.CreateProjectilePlayerWeapon(_projectilePrefab, _attackPoint.position);
            projectile.Init(targetTransform, _attackSpeed, _attackPower);
            projectile.MoveToTarget();
        }
    }
}
