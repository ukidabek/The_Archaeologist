using UnityEngine;

namespace Code.StateLogic
{
    public class AimShootLocomotionAnimationStateLogic : LocomotionAnimationStateLogicBase
    {
        [SerializeField] private string _animYName = "Y";
        [SerializeField] private string _animXName = "X";
        [SerializeField] private string _animAimName = "Aim";
        [SerializeField] private string _animFireName = "Fire";
        
        private int _animYID;
        private int _animXID;
        private int _animAimID;
        private int _animFireID;

        private float _inputY = 0, _inputX = 0;

        public override void Activate()
        {
            _animator.SetBool(_animAimID, true);
        }

        public override void Deactivate()
        {
            _animator.SetFloat(_animXID, 0);
            _animator.SetBool(_animAimID, false);
        }

        protected override void AssignAnimationIDs()
        {
            base.AssignAnimationIDs();
            _animYID = Animator.StringToHash(_animYName);
            _animXID = Animator.StringToHash(_animXName);
            _animAimID = Animator.StringToHash(_animAimName);
            _animFireID = Animator.StringToHash(_animFireName);
        }
        
        public override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);

            var input = _input.move;
            var sprint = _input.sprint;
            var fire = _input.fire;
            var canSprint = sprint && !fire;
            
            var newInputY = canSprint ? input.y * 2f : input.y;
            var newInputX = canSprint ? input.x * 2f : input.x;

            _inputY = Mathf.Lerp(_inputY, newInputY, deltaTime * SpeedChangeRate);
            _inputX = Mathf.Lerp(_inputX, newInputX, deltaTime * SpeedChangeRate);
            
            _animator.SetFloat(_animYID, _inputY);
            _animator.SetFloat(_animXID, _inputX);
            
            _animator.SetBool(_animFireID, fire);
        }
    }
}