using System;
using System.Collections;
using Logic.States;
using UnityEngine;
using Utilities.General;

namespace Code.StateLogic
{
    public class AnimatorInStateCondition : SwitchStateCondition
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private AnimatorParameterDefinition _isReloadingParameterDefinition = null;
        [SerializeField] private int _layerIndex = 0;
        [SerializeField] private string _name = "";

        private WaitUntil _waitUntilReloadingIsStarted;
        private WaitUntil _waitUntilReloadingIsEnded;
        private bool _status = false;

        private void Awake()
        {
            _waitUntilReloadingIsStarted = new WaitUntil(() => _isReloadingParameterDefinition.GetBool(_animator));
            _waitUntilReloadingIsEnded = new WaitUntil(() => !_isReloadingParameterDefinition.GetBool(_animator));

        }

        public override void Activate()
        {
            _status = false;
            StartCoroutine(X());
        }

        IEnumerator X()
        {
            yield return _waitUntilReloadingIsStarted;
            yield return _waitUntilReloadingIsEnded;
            _status = true;
        }
        public override bool Condition => _status;
    }
}