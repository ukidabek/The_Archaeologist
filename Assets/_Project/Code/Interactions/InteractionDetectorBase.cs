using System;
using System.Collections.Generic;
using Interactions;
using UnityEngine;

namespace Code.StateLogic
{
    public abstract class InteractionDetectorBase : MonoBehaviour
    {
        public event Action<IEnumerable<IInteractable>> OnDetectionStatusChanged;
        
        protected void InvokeOnInteractionDetected(IEnumerable<IInteractable> interactable)
            => OnDetectionStatusChanged?.Invoke(interactable);
    }
}