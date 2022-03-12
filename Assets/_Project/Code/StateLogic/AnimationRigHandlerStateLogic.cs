using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Code.StateLogic
{
    public class AnimationRigHandlerStateLogic : Logic.States.StateLogic
    {
        [Serializable]
        public class RigHandler
        {
            [SerializeField] private Rig _constraint = null;

            private IEnumerator _coroutine = null;

            [SerializeField, Range(0f, 1f)] private float _activateWeight = 1f; 
            [SerializeField, Range(0f, 1f)] private float _deactivateWeight = 0f;

            [SerializeField] private float _weightTransitionSpeed = 10;
            
            public  void Activate(AnimationRigHandlerStateLogic rigHandler)
            {
                ManageCoroutine(SetWeightCoroutine(_activateWeight), rigHandler);
            }

            private void ManageCoroutine(IEnumerator enumerator, AnimationRigHandlerStateLogic rigHandler)
            {
                if (_coroutine != null)
                    rigHandler.StopCoroutine(_coroutine);
                _coroutine = enumerator;
                rigHandler.StartCoroutine(_coroutine);
            }

            public void Deactivate(AnimationRigHandlerStateLogic rigHandler)
            {
                ManageCoroutine(SetWeightCoroutine(_deactivateWeight), rigHandler);
            }
            
            private IEnumerator SetWeightCoroutine(float targetWeight)
            {
                while (_constraint.weight != targetWeight)
                {
                    var speed = _weightTransitionSpeed * Time.deltaTime;
                    _constraint.weight = Mathf.MoveTowards(_constraint.weight, targetWeight, speed);
                    yield return null;
                }
            }
        }

        [SerializeField] private RigHandler[] _rigHandlers = null;

        public override void Activate()
        {
            foreach (var rigHandler in _rigHandlers)
            {
                rigHandler.Activate(this);
            }
        }


        public override void Deactivate()
        {
            foreach (var rigHandler in _rigHandlers)
            {
                rigHandler.Deactivate(this);
            }
        }
    }
}