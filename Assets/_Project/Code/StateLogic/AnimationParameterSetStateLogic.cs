using UnityEngine;
using Utilities.General;

namespace Code.StateLogic
{
    public class AnimationParameterSetStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private AnimatorParameterDefinition _parameterDefinition;
        [SerializeField] private Animator _animator = null;
        [SerializeField] private AnimationParameterSetLogic _animationParameterSetLogic = null;

        public override void Activate() => 
            _animationParameterSetLogic.SetOnActivate(_animator, _parameterDefinition);

        public override void Deactivate() => 
            _animationParameterSetLogic.SetOnActivate(_animator, _parameterDefinition);
    }
}