using UnityEngine;

namespace Game.Scripts.Enemies
{
    public class ShootingEnemy : Enemy
    {
        public override void Attack()
        {
            Debug.Log("shooting enemy attack");
        }
    }
}
