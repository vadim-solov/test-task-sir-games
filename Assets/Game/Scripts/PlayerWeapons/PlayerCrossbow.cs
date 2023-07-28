using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerCrossbow : PlayerWeapon
    {
        protected override void Fire(Vector3 targetPosition)
        {
            Debug.Log("PlayerCrossbow shoot!");
        }
    }
}
