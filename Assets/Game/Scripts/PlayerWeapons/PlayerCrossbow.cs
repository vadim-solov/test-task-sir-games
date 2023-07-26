using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerCrossbow : PlayerWeapon
    {
        public override void Fire()
        {
            Debug.Log("PlayerCrossbow shoot!");
        }
    }
}
