using System.Collections.Generic;
using Interactions;
using UnityEngine;

namespace Code.StateLogic
{
    public abstract class InteractionSelectorBase : MonoBehaviour, IInteractionSelector
    {
        public abstract IEnumerable<IInteractable> SelectedInteractions { get; }
        public abstract void Select(IEnumerable<IInteractable> interactables);
    }
}