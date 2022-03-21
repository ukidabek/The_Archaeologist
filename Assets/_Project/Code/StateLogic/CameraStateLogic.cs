using Cinemachine;
using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
	public class CameraStateLogic : Logic.States.StateLogic, IOnLateUpdateLogic
	{
		[Header("Cinemachine")]
		[Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
		public GameObject CinemachineCameraTarget;
		
		[Tooltip("How far in degrees can you move the camera up")]
		public float TopClamp = 70.0f;

		[Tooltip("How far in degrees can you move the camera down")]
		public float BottomClamp = -30.0f;
		
		[Tooltip("For locking the camera position on all axis")]
		public bool LockCameraPosition = false;
		
		public Vector2 _rotationSpeed = new Vector2(10, 10);

		[SerializeField] private CameraStateLogicData _cameraData = null;
	
		[SerializeField] private StarterAssetsInputs _input;
		
		private const float _threshold = 0.01f;

		public void OnLateUpdate(float deltaTime)
		{
			CameraRotation(deltaTime);
		}
    
		private void CameraRotation(float deltaTime)
		{
			var cinemachineTargetYaw = _cameraData.CinemachineTargetYaw;
			var cinemachineTargetPitch = _cameraData.CinemachineTargetPitch;
			
			// if there is an input and camera position is not fixed
			if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
			{
				cinemachineTargetYaw += _input.look.x * _rotationSpeed.x * deltaTime;
				cinemachineTargetPitch += _input.look.y * _rotationSpeed.y * deltaTime;
			}

			// clamp our rotations so our values are limited 360 degrees
			cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
			cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, BottomClamp, TopClamp);


			_cameraData.CinemachineTargetYaw = cinemachineTargetYaw;
			_cameraData.CinemachineTargetPitch = cinemachineTargetPitch;
			_cameraData.Apply();
		}
    
		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}
	}
}
