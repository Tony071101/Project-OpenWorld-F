using UnityEngine;

namespace OpenWorldF
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerStateManager : MonoBehaviour
    {
        [field: SerializeField] public PlayerSO Data { get; private set; }
        [field: SerializeField] public CapsuleColliderUtility ColliderUtility { get; private set; }
        [field: SerializeField] public LayerMask LayerData { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public Transform MainCameraTransform { get; private set; }
        public PlayerController InputActions { get; private set; }
        public PlayerController.PlayerActions PlayerActions { get; private set; }
        private PlayerMovementStateMachineManager movementStateMachineManager;

        private void Awake() {
            Rigidbody = GetComponent<Rigidbody>();
            InputActions = new PlayerController();
            PlayerActions = InputActions.Player;
            // ColliderUtility.Initialize(gameObject);
            // ColliderUtility.CalculateCapsuleColliderDimension();
            MainCameraTransform = Camera.main.transform;
            movementStateMachineManager = new PlayerMovementStateMachineManager(this);
        }

        private void Start() {
            movementStateMachineManager.ChangeState(movementStateMachineManager.RunState);
        }

        private void Update() {
            movementStateMachineManager.HandleInput();
            movementStateMachineManager.Update();
        }

        private void FixedUpdate() {
            movementStateMachineManager.FixedUpdate();
        }

        private void OnEnable() {
            InputActions.Enable();
        }

        private void OnDisable() {
            InputActions.Disable();
        }
    }
}
