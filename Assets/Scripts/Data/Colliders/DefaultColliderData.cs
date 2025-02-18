using System;
using UnityEngine;

namespace OpenWorldF
{
    [Serializable]
    public class DefaultColliderData
    {
        [SerializeField] public float Height { get; private set; } = 1.8f;
        [SerializeField] public float CenterY { get; private set; } = 0.9f;
        [SerializeField] public float Radius { get; private set; } = 0.2f;
    }
}
