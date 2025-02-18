using System;
using UnityEngine;

namespace OpenWorldF
{
    [Serializable]
    public class SlopeData
    {
        [SerializeField] [Range(0f, 1f)] public float StepHeightPercentage { get; private set; } = 0.25f;
        [SerializeField] [Range(0f, 5f)] public float FloatRaycastDistance { get; private set; } = 2f;
        [SerializeField] [Range(0f, 50f)] public float StepReachForce { get; private set; } = 25f;
    }
}
