using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorldF
{
    public class PlayerGroundedState : PlayerMovementStateManager
    {
        private SlopeData slopeData;
        public PlayerGroundedState(PlayerMovementStateMachineManager playerMovementStateMachineManager) : base(playerMovementStateMachineManager)
        {
            slopeData = stateMachineManager.Player.ColliderUtility.SlopeData;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        protected virtual void OnMove()
        {
            stateMachineManager.ChangeState(stateMachineManager.RunState);
        }
    }
}
