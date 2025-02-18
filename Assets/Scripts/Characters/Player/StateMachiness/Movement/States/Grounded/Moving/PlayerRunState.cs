using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorldF
{
    public class PlayerRunState : PlayerGroundedState
    {
        public PlayerRunState(PlayerMovementStateMachineManager playerMovementStateMachineManager) : base(playerMovementStateMachineManager)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateMachineManager.ReusableData.MovementSpeedModifier = movementData.RunData.SpeedModifier;
        }
    }
}
