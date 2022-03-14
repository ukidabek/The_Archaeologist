using System.Collections.Generic;

namespace Interactions
{
    public class InteractionManager
    {
        private readonly IInteractionSelector _interactionSelector = null;
        
        private readonly UnityEngine.Object _user = null;
        private readonly List<IInteractable> _detectedInteractions = new List<IInteractable>();

        public InteractionManager(IInteractionSelector interactionSelector, UnityEngine.Object user)
        {
            _interactionSelector = interactionSelector;
            _user = user;
        }

        private void OnInteractionDetected(IInteractable interactable)
        {
            if(!_detectedInteractions.Contains(interactable))
                _detectedInteractions.Add(interactable);
            
            _interactionSelector.Select(_detectedInteractions);
        }

        private void OnInteractionLost(IInteractable interactable)
        {
            if(_detectedInteractions.Contains(interactable))
                _detectedInteractions.Remove(interactable);
            
            _interactionSelector.Select(_detectedInteractions);
        }

        public void Interact()
        {
            foreach (var detectedPickUp in _interactionSelector.SelectedInteractions) 
                detectedPickUp.Interact(_user);
        }
    }
}