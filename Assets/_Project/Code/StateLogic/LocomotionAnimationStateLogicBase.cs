using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public abstract class LocomotionAnimationStateLogicBase : Logic.States.StateLogic, IOnUpdateLogic
    {
        [SerializeField] protected LocomotionStateLogicBase _locomotionStateLogic = null;
        [SerializeField] protected StarterAssetsInputs _input;
        [SerializeField] protected Animator _animator;
        [SerializeField] private string _animNameGrounded = "Grounded";

        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;

        protected int _animIDGrounded;
        
        protected float _animationBlend;

        protected virtual void AssignAnimationIDs()
        {
            _animIDGrounded = Animator.StringToHash(_animNameGrounded);
        }

        protected virtual void Awake()
        {
            AssignAnimationIDs();
        }

        public virtual void OnUpdate(float deltaTime)
        {
            var grounded = _locomotionStateLogic.Grounded;
            _animator.SetBool(_animIDGrounded, grounded);
        }

        protected float GetAnimationAxisValue(float current, float targetSpeed, AnimationCurve curve, float deltaTime = -1)
        {
            deltaTime = deltaTime < 0 ? Time.deltaTime : deltaTime;
            
            targetSpeed = curve.Evaluate(targetSpeed);
            return Mathf.Lerp(current, targetSpeed, deltaTime * SpeedChangeRate);
        }
    }
}