using Game.Scripts.PlayerWeapons;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class CurrentPlayerWeapon : MonoBehaviour
    {
        [SerializeField]
        private Transform _weaponPoint;

        public PlayerWeapon CurrentWeapon { get; private set; }

        public void SetWeapon(PlayerWeapon playerWeapon)
        {
            CurrentWeapon = playerWeapon;
            playerWeapon.transform.SetParent(_weaponPoint);
            playerWeapon.transform.position = _weaponPoint.transform.position;
        }
    }
}
