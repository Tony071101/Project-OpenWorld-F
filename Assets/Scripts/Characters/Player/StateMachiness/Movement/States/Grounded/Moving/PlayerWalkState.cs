using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorldF
{
    public class PlayerWalkState : PlayerGroundedState
    {
        public PlayerWalkState(PlayerMovementStateMachineManager playerMovementStateMachineManager) : base(playerMovementStateMachineManager)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateMachineManager.ReusableData.MovementSpeedModifier = movementData.WalkData.SpeedModifier;
        }
    }
}
