using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Code.StateLogic
{
    public class RigHandler : MonoBehaviour
    {
        [SerializeField] private Rig _constraint = null;

        private IEnumerator _coroutine = null;

        [SerializeField] public TransitionSettings _settings;
        public TransitionSettings Settings
        {
            get => _settings;
            set => _settings = value;
        }

        public  void Activate()
        {
            // _constraint.weight = _activateWeight;
            ManageCoroutine(SetWeightCoroutine(_settings.ActivateWeight));
        }

        private void ManageCoroutine(IEnumerator enumerator)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = enumerator;
            StartCoroutine(_coroutine);
        }

        public void Deactivate()
        {
            ManageCoroutine(SetWeightCoroutine(_settings.DeactivateWeight));
        }
            
        private IEnumerator SetWeightCoroutine(float targetWeight)
        {
            var transitionSpeed = _settings.WeightTransitionSpeed;
            while (_constraint.weight != targetWeight)
            {
                var speed = transitionSpeed * Time.deltaTime;
                _constraint.weight = Mathf.MoveTowards(_constraint.weight, targetWeight, speed);
                yield return null;
            }
        }
    }
}