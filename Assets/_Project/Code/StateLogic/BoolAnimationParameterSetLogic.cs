using UnityEngine;
using Utilities.General;

namespace Code.StateLogic
{
    public class BoolAnimationParameterSetLogic : AnimationParameterSetLogic
    {
        [SerializeField] private bool _onActivateValue = true;
        [SerializeField] private bool _onDeactivateValue = false;

        public override void SetOnActivate(Animator animator, AnimatorParameterDefinition parameterDefinition) => 
            parameterDefinition.SetBool(animator, _onActivateValue);

        public override void SetOnDeactivate(Animator animator, AnimatorParameterDefinition parameterDefinition) => 
            parameterDefinition.SetBool(animator, _onDeactivateValue);
    }
}