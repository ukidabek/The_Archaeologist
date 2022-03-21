using Logic.States;
using UnityEngine;

namespace Code.StateLogic
{
    public class SetAnimatorWeightTransitionLogic : StateTransitionLogicWithCoroutineBase
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private float target = 1f;
        [SerializeField] private float speed = 0;
        [SerializeField] private int _index;

        protected override void Perform()
        {
            _manager.Run(StateLogicHelpers.SetLayerWeight(
                _animator,
                _index,
                target,
                speed));
        }

        public override void Cancel() => _manager.Stop();
    }
}