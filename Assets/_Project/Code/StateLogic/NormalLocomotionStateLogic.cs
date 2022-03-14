using Logic.States;
using UnityEngine;

namespace Code.StateLogic
{
	public class NormalLocomotionStateLogic : LocomotionStateLogicBase, IOnUpdateLogic
	{
		private float _rotationVelocity;

		protected override void Move(float deltaTime)
		{
			base.Move(deltaTime);
			// normalise input direction
			if (_input.move == Vector2.zero) return;
			
			var transform = _controller.transform;
			var yRotation = transform.rotation.eulerAngles.y;
			var rotation = Mathf.SmoothDampAngle(yRotation, _targetRotation, ref _rotationVelocity,
				RotationSmoothTime);

			// rotate to face input direction relative to camera position
			transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
		}

		public void OnUpdate(float deltaTime)
		{
			Execute(deltaTime);
		}
	}
}
