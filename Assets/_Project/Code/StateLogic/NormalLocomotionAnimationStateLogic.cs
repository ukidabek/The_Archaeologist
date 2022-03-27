using UnityEngine;
using Utilities.General;

namespace Code.StateLogic
{
    public class NormalLocomotionAnimationStateLogic : LocomotionAnimationStateLogicBase
    {
        [SerializeField] private AnimationCurve m_speedToAxis = new AnimationCurve();

        [SerializeField] private AnimatorParameterDefinition _ySpeedParameter = null;
        
        public override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);
            var targetSpeed = _locomotionStateLogic.Speed;

            _animationBlend = GetAnimationAxisValue(_animationBlend, targetSpeed, m_speedToAxis, deltaTime);
            _ySpeedParameter.SetFloat(_animator, _animationBlend);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            _ySpeedParameter.SetFloat(_animator, 0);
        }
    }
}