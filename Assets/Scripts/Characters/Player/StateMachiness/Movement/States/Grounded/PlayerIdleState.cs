using System;
using Unity.VisualScripting;
using UnityEngine;

namespace OpenWorldF
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(PlayerMovementStateMachineManager playerMovementStateMachineManager) : base(playerMovementStateMachineManager)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateMachineManager.ReusableData.MovementSpeedModifier = 0f;
            ResetVelocity();
        }

        public override void Update()
        {
            base.Update();

            if(stateMachineManager.ReusableData.MovementInput != Vector2.zero) {
                OnMove();
            }

        }
    }
}
