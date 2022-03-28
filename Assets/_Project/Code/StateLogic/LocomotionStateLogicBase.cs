using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public abstract class LocomotionStateLogicBase : Logic.States.StateLogic
    {
        [SerializeField] protected CharacterController _controller;
        [SerializeField] protected StarterAssetsInputs _input;
        [SerializeField] protected GameObject _mainCamera;

        [Space]
        [Header("Player")]
        [Tooltip("Move speed of the character in m/s")]
        public float MoveSpeed = 2.0f;

        [Tooltip("Sprint speed of the character in m/s")]
        public float SprintSpeed = 5.335f;

        [Tooltip("How fast the character turns to face movement direction")]
        [Range(0.0f, 0.3f)]
        public float RotationSmoothTime = 0.12f;

        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;

        [Space(10)]
        [Tooltip("The height the player can jump")]
        public float JumpHeight = 1.2f;

        [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        public float Gravity = -15.0f;

        [Space(10)]
        [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
        public float JumpTimeout = 0.50f;

        [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
        public float FallTimeout = 0.15f;

        [Header("Player Grounded")]
        [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        public bool Grounded = true;

        [Tooltip("Useful for rough ground")]
        public float GroundedOffset = -0.14f;

        [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        public float GroundedRadius = 0.28f;

        [Tooltip("What layers the character uses as ground")]
        public LayerMask GroundLayers;

        protected float _targetRotation = 0.0f;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;
        private Vector3 _moveVector = Vector3.zero;
        private Vector3 _sharePosition = Vector3.zero;
        private Vector3 _speedVector = Vector3.zero;
        private Vector3 _inputDirection = Vector3.zero;
        private float _targetSpeed;

        public bool CanJump => _jumpTimeoutDelta <= 0.0f;
        public float Speed { get; private set; }
        public Vector3 TargetDirection { get; protected set; }

        protected virtual void Execute(float deltaTime)
        {
            JumpAndGravity(deltaTime);
            GroundedCheck();
            Move(deltaTime);
        }

        private void GroundedCheck()
        {
            _sharePosition.Set(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
            // set sphere position, with offset
            Grounded = Physics.CheckSphere(_sharePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
        }

        protected virtual void Move(float deltaTime)
        {
            _targetSpeed = CalculateSpeed();

            // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

            // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is no input, set the target speed to 0
            if (_input.move == Vector2.zero) _targetSpeed = 0.0f;

            // a reference to the players current horizontal velocity
            _speedVector.Set(_controller.velocity.x, 0.0f, _controller.velocity.z);
            var _currentHorizontalSpeed = _speedVector.magnitude;

            var speedOffset = 0.1f;
            var inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // accelerate or decelerate to target speed
            if (_currentHorizontalSpeed < _targetSpeed - speedOffset || _currentHorizontalSpeed > _targetSpeed + speedOffset)
            {
                // creates curved result rather than a linear one giving a more organic speed change
                // note T in Lerp is clamped, so we don't need to clamp our speed
                Speed = Mathf.Lerp(_currentHorizontalSpeed, _targetSpeed * inputMagnitude, deltaTime * SpeedChangeRate);

                // round speed to 3 decimal places
                Speed = Mathf.Round(Speed * 1000f) / 1000f;
            }
            else
            {
                Speed = _targetSpeed;
            }
			
            _inputDirection.Set(_input.move.x, 0.0f, _input.move.y);
            _inputDirection.Normalize();
            
            // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is a move input rotate player when the player is moving
            if (_input.move != Vector2.zero)
            {
                var atan2 = Mathf.Atan2(_inputDirection.x, _inputDirection.z);
                _targetRotation = atan2 * Mathf.Rad2Deg + _mainCamera.transform.eulerAngles.y;
            }

            TargetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            TargetDirection.Normalize();
            
            _moveVector.Set(0f, _verticalVelocity, 0f);
	    
            // move the player
            _controller.Move(TargetDirection * (Speed * deltaTime) + _moveVector * deltaTime);
        }

        protected virtual float CalculateSpeed() =>
            // set target speed based on move speed, sprint speed and if sprint is pressed
            _input.sprint ? SprintSpeed : MoveSpeed;

        private void JumpAndGravity(float deltaTime)
        {
            if (Grounded)
            {
                // reset the fall timeout timer
                _fallTimeoutDelta = FallTimeout;

                // update animator if using character
		    

                // stop our velocity dropping infinitely when grounded
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                // Jump
                if (_input.jump && CanJump)
                {
                    // the square root of H * -2 * G = how much velocity needed to reach desired height
                    _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);
                }

                // jump timeout
                if (!CanJump)
                {
                    _jumpTimeoutDelta -= deltaTime;
                }
            }
            else
            {
                // reset the jump timeout timer
                _jumpTimeoutDelta = JumpTimeout;

                // fall timeout
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= deltaTime;
                }

                // if we are not grounded, do not jump
                _input.jump = false;
            }

            // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += Gravity * deltaTime;
            }
        }
    }
}