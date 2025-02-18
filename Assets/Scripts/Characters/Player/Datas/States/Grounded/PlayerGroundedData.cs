using System;
using UnityEngine;

namespace OpenWorldF
{
    [Serializable]
    public class PlayerGroundedData
    {
        [field: SerializeField] [field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;
        [field: SerializeField] [field: Range(0f, 25f)] public float HorizontalSpeed { get; private set; } = 10f;
        [field: SerializeField] public float RightLimit { get; private set; } = 9.5f;
        [field: SerializeField] public float LeftLimit { get; private set; } = -9f;

        [field: SerializeField] public AnimationCurve SlopeSpeedAngles { get; private set; }
        [field: SerializeField] public PlayerRotationData BaseRotationData { get; private set; }
        [field: SerializeField] public PlayerWalkData WalkData { get; private set; }
        [field: SerializeField] public PlayerRunData RunData { get; private set; }
    }
}
