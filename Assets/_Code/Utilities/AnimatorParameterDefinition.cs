using UnityEngine;

namespace Utilities.General
{
    [CreateAssetMenu(fileName = "AnimationParameter", menuName = "Utilities/AnimationParameter")]
    public class AnimatorParameterDefinition : AnimatorDefinitionBase
    {
        [SerializeField] private string _name = string.Empty;
        [SerializeField] private int _hash = 0;
        
        public void SetInt(Animator animator, int value) => animator.SetInteger(_hash, value);

        public void SetBool(Animator animator, bool value) => animator.SetBool(_hash, value);

        public void SetFloat(Animator animator, float value) => animator.SetFloat(_hash, value);

        public void SetTrigger(Animator animator) => animator.SetTrigger(_hash);

        public void ResetTrigger(Animator animator) => animator.ResetTrigger(_hash);
    }
}