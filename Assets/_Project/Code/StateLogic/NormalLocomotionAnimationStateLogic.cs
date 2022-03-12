using UnityEngine;

namespace Code.StateLogic
{
    public class NormalLocomotionAnimationStateLogic : LocomotionAnimationStateLogicBase
    {
        [SerializeField] private AnimationCurve m_speedToAxis = new AnimationCurve();

        [SerializeField] private string _animYNameSpeed = "Y";
        private int _animIDSpeed;

        protected override void AssignAnimationIDs()
        {
            base.AssignAnimationIDs();
            _animIDSpeed = Animator.StringToHash(_animYNameSpeed);
        }

        public override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);
            var targetSpeed = _locomotionStateLogic.Speed;

            _animationBlend = GetAnimationAxisValue(_animationBlend, targetSpeed, m_speedToAxis, deltaTime);

            _animator.SetFloat(_animIDSpeed, _animationBlend);
        }
    }
}