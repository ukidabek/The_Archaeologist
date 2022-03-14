using System;
using UnityEngine;

namespace Code.StateLogic
{
    [Serializable]
    public struct TransitionSettings
    {
        [SerializeField] private float _activateDelay;

        public float ActivateDelay => _activateDelay;

        [SerializeField, Range(0f, 1f)] private float _activateWeight ;
        public float ActivateWeight => _activateWeight;

        [SerializeField] private float _deactivationDelay;

        public float DeactivationDelay => _deactivationDelay;

        [SerializeField, Range(0f, 1f)] private float _deactivateWeight ;
        public float DeactivateWeight => _deactivateWeight;

        [SerializeField] private float _weightTransitionSpeed ;
        public float WeightTransitionSpeed => _weightTransitionSpeed;
    }
}