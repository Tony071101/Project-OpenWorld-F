using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenWorldF
{
    public class PlayerMovementStateManager : IState
    {
        protected PlayerMovementStateMachineManager stateMachineManager;
        protected PlayerGroundedData movementData;

        public PlayerMovementStateManager(PlayerMovementStateMachineManager playerMovementStateMachineManager) {
            stateMachineManager = playerMovementStateMachineManager;

            movementData = stateMachineManager.Player.Data.GroundedData;

            InitializeData();
        }

        private void InitializeData()
        {
            stateMachineManager.ReusableData.TimeToReachTargetRotation = movementData.BaseRotationData.TargetRotationReachTime;
        }

        public virtual void Enter()
        {
            Debug.Log("State: " + GetType().Name);
        }


        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
            Move();
        }

        public virtual void HandleInput()
        {
            ReadMovementInput();
        }
            

        private void ReadMovementInput()
        {
            stateMachineManager.ReusableData.MovementInput = stateMachineManager.Player.PlayerActions.PlayerMove.ReadValue<Vector2>();
        }

        private void Move()
        {
            if(stateMachineManager.ReusableData.MovementSpeedModifier == 0f) {
                return;
            }
            float movementSpeed = GetMovementSpeed();
            float horizontalMovementSpeed = GetHorizontalMovementSpeed();
            float moveDirection = stateMachineManager.ReusableData.MovementInput.x;
            bool leftBorder = moveDirection < 0 && stateMachineManager.Player.transform.position.x > movementData.LeftLimit;
            bool rightBorder = moveDirection > 0 && stateMachineManager.Player.transform.position.x < movementData.RightLimit;

            stateMachineManager.Player.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.World);

            if (moveDirection != 0 && (leftBorder || rightBorder)) {
                stateMachineManager.Player.transform.Translate(Vector3.right * moveDirection * Time.deltaTime * horizontalMovementSpeed, Space.World);
            }
        }

        protected Vector3 GetMovementInputDirection()
        {
            return new Vector3(stateMachineManager.ReusableData.MovementInput.x, 0f, stateMachineManager.ReusableData.MovementInput.y);
        }

        protected float GetMovementSpeed()
        {
            return movementData.BaseSpeed * stateMachineManager.ReusableData.MovementSpeedModifier;
        }

        protected float GetHorizontalMovementSpeed()
        {
            return movementData.HorizontalSpeed * stateMachineManager.ReusableData.HorizontalMovementSpeedModifier;
        }
        
        protected void ResetVelocity() {
            stateMachineManager.Player.Rigidbody.linearVelocity = Vector3.zero;
        }
    }
}
