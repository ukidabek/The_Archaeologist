using Logic.States;
using UnityEngine;

namespace Code.StateLogic
{
    public class AimShootLocomotionState : LocomotionStateLogicBase, IOnUpdateLogic
    {
        protected override void Move(float deltaTime)
        {
            base.Move(deltaTime);
            var transform = _mainCamera.transform;
            var yRotation = transform.rotation.eulerAngles.y;
            _controller.transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
        }

        protected override float CalculateSpeed()
        {
            return _input.fire ? MoveSpeed : base.CalculateSpeed();
        }

        public void OnUpdate(float deltaTime)
        {
            Execute(deltaTime);
        }
    }
}
