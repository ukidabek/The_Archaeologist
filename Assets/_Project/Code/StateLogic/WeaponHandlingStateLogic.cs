using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class WeaponHandlingStateLogic : Logic.States.StateLogic, IOnUpdateLogic
    {
        [SerializeField] private StarterAssetsInputs _inputs = null;
        [SerializeField] private Animator _animator = null;
        [SerializeField] private string _fireBoolName = "Fire";
        private int _fireBoolID = 0;

        private bool _deactivated = false;
        
        private void Awake()
        {
            _fireBoolID = Animator.StringToHash(_fireBoolName);
        }

        public override void Activate()
        {
            _deactivated = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if(!_deactivated) return;
            
            _animator.SetBool(_fireBoolID, _inputs.fire);
        }

        public override void Deactivate()
        {
            _deactivated = false;
            _animator.SetBool(_fireBoolID, false);
        }
    }
}