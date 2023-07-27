using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerCrossbow : PlayerWeapon
    {
        protected override void Fire(Transform targetTransform)
        {
            Debug.Log("PlayerCrossbow shoot!");
        }
    }
}
