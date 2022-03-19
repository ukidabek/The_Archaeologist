using Logic.States;
using UnityEngine;

namespace Code.StateLogic
{
    public class AnimatorInStateCondition : SwitchStateCondition
    {
        [SerializeField] private Animator _animator = null;
        [SerializeField] private int _layerIndex = 0;
        [SerializeField] private string _stateName = null;

        public override bool Condition
        {
            get
            {
                var currentStateInfo = _animator.GetCurrentAnimatorStateInfo(_layerIndex);
                return !currentStateInfo.IsName(_stateName);
            }
        }
    }
}