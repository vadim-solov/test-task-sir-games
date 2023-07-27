using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerCrossbow : PlayerWeapon
    {
        protected override void Fire()
        {
            Debug.Log("PlayerCrossbow shoot!");
        }
    }
}
