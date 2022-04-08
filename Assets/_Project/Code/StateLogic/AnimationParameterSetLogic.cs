using UnityEngine;
using Utilities.General;

namespace Code.StateLogic
{
    public abstract class AnimationParameterSetLogic : MonoBehaviour
    {
        public abstract void SetOnActivate(Animator animator, AnimatorParameterDefinition parameterDefinition);
        public abstract void SetOnDeactivate(Animator animator,AnimatorParameterDefinition parameterDefinition);

    }
}