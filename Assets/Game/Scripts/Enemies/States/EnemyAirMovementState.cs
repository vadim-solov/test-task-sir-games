﻿using UnityEngine;

namespace Game.Scripts.Enemies.States
{
    public class EnemyAirMovementState : EnemyMovementState
    {
        public override void Enter()
        {
        }

        public override void Run()
        {
            MoveToTarget();
            RotateToTarget();
        }

        public override void Exit()
        {
        }

        private void MoveToTarget()
        {
            Vector3 directionToPlayer = _target.Instance.transform.position - transform.position;
            directionToPlayer.y = 0f;
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * 1f * Time.deltaTime;
        }
    }
}