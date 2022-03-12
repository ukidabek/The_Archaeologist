using System;
using UnityEngine;

namespace Code.StateLogic
{
    public class CameraStateLogicData : MonoBehaviour
    {
        // cinemachine
        [SerializeField] private float _cinemachineTargetYaw;
        [SerializeField] private float _cinemachineTargetPitch;

        public float CinemachineTargetYaw
        {
            get => _cinemachineTargetYaw;
            set => _cinemachineTargetYaw = value;
        }

        public float CinemachineTargetPitch
        {
            get => _cinemachineTargetPitch;
            set => _cinemachineTargetPitch = value;
        }

        private void Awake()
        {
            var rotation = transform.eulerAngles;
            
            _cinemachineTargetPitch = rotation.x;
            _cinemachineTargetYaw = rotation.y;
        }

        public void Apply()
        {
            // Cinemachine will follow this target
            transform.rotation = Quaternion.Euler(_cinemachineTargetPitch , _cinemachineTargetYaw, 0.0f);
        }
    }
}