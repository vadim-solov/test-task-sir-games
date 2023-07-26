using UnityEngine;

namespace Game.Scripts.PlayerWeapons
{
    public class PlayerBow : PlayerWeapon
    {
        public override void Fire()
        {
            Debug.Log("PlayerDefaultBow shoot!");
        }
    }
}
