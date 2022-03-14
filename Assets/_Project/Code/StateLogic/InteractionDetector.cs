using System.Collections.Generic;
using Interactions;
using UnityEngine;

namespace Code.StateLogic
{
    public class InteractionDetector : InteractionDetectorBase
    {
        [SerializeField] private Collider _collider = null;

        private readonly List<IInteractable> _detectedInteractions = new List<IInteractable>();

        private void OnEnable()
        {
            _collider.enabled = true;
        }

        private void OnDisable()
        {
            _collider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.gameObject.GetComponent<IInteractable>();
            if(interactable == null || _detectedInteractions.Contains(interactable)) return;
            _detectedInteractions.Add(interactable);
            InvokeOnInteractionDetected(_detectedInteractions);
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.gameObject.GetComponent<IInteractable>();
            if (interactable == null || !_detectedInteractions.Contains(interactable)) return;
            _detectedInteractions.Remove(interactable);
            InvokeOnInteractionDetected(_detectedInteractions);
        }

        private void Update()
        {
            var preFiltrationCount = _detectedInteractions.Count; 
            var count = preFiltrationCount - 1;
            for (var i = count; i >= 0; i--)
            {
                if (_detectedInteractions[i].Equals(null))
                {
                  _detectedInteractions.RemoveAt(i);
                }
                else if(_detectedInteractions[i].Interactable == false)
                {
                    _detectedInteractions.RemoveAt(i);
                }
            }
            
            if(_detectedInteractions.Count != preFiltrationCount)
                InvokeOnInteractionDetected(_detectedInteractions);

        }
    }
}