using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerBow : PlayerWeapon
    {
        protected override void Fire()
        {
            Debug.Log("PlayerDefaultBow shoot!");
            PlayerWeaponProjectile projectile = _gameObjectFactory.CreateProjectilePlayerWeapon(_projectilePrefab);
            projectile.transform.position = _attackPoint.position;
        }
    }
}
