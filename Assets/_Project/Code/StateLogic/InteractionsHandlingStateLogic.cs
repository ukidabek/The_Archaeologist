using Logic.Interactions;
using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class InteractionsHandlingStateLogic : Logic.States.StateLogic, IOnUpdateLogic
    {
        [SerializeField] private InteractionDetectorBase _interactionDetector;
        [SerializeField] private InteractionSelectorBase _interactionSelector;
        [SerializeField] private GameObject _user = null;
        [SerializeField] private StarterAssetsInputs _inputs;
        
        private InteractionManager _interactionManager = null;

        public override void Activate()
        {
            _interactionDetector.enabled = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inputs.interact)
            {
                _inputs.interact = false;
                _interactionManager.ManualInteract();
            }
            
            _interactionManager.AutoInteract();
        }
        
        public override void Deactivate()
        {
            _interactionDetector.enabled = false;
        }

        private void Awake()
        {
            _interactionManager = new InteractionManager(_interactionSelector, _user);
        }
        
    }
}