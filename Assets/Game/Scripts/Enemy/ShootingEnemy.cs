using UnityEngine;

namespace Game.Scripts.Enemy
{
    public class ShootingEnemy : Enemy
    {
        public override void Attack()
        {
            Debug.Log("shooting enemy attack");
        }
    }
}
