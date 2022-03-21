using System;
using Logic.States;
using UnityEngine;

namespace Code.StateLogic
{
    public class LayerSwitcherStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _layerName = String.Empty;
        [SerializeField] private int _layerIndex = -1;

        [SerializeField] private TransitionSettings _settings = new TransitionSettings();
        
        private CoroutineManager _coroutineManager;

        private void Awake()
        {
            _coroutineManager = new CoroutineManager(this);
        }

        private void Start()
        {
            if (_layerIndex < 0) 
                _layerIndex = _animator.GetLayerIndex(_layerName);
        }

        public override void Activate()
        {
            _coroutineManager.Run(StateLogicHelpers.SetLayerWeight(
                _animator,
                _layerIndex, 
                _settings.ActivateWeight, 
                _settings.WeightTransitionSpeed,
                _settings.ActivateDelay));
        }

        public override void Deactivate()
        {
            _coroutineManager.Run(StateLogicHelpers.SetLayerWeight(
                _animator,
                _layerIndex, 
                _settings.DeactivateWeight, 
                _settings.WeightTransitionSpeed,
                _settings.DeactivationDelay));
        }

        
    }
}