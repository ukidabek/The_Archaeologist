using Logic.States;
using UnityEngine;

namespace Code.StateLogic
{
    public class AimShootLocomotionState : LocomotionStateLogicBase, IOnLateUpdateLogic
    {
        [SerializeField] private Transform _cameraRoot = null;
        
        protected override void Move(float deltaTime)
        {
            base.Move(deltaTime);
            var transform = _mainCamera.transform;
            var yRotation = transform.rotation.eulerAngles.y;
            _controller.transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
            
            var localRotationEulerAngles = _cameraRoot.localRotation.eulerAngles;
            localRotationEulerAngles.y = 0;
            _cameraRoot.localRotation = Quaternion.Euler(localRotationEulerAngles);
        }

        protected override float CalculateSpeed() => _input.fire ? MoveSpeed : base.CalculateSpeed();

        public void OnLateUpdate(float deltaTime) => Execute(deltaTime);
    }
}
