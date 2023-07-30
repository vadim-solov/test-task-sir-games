using UnityEngine;

namespace Game.Scripts.Player
{
    public class PlayerHealth : Health
    {
        protected override void Die()
        {
            Debug.Log("player die");
        }
    }
}
