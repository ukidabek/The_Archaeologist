using Logic.States;
using StarterAssets;
using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class FireWeaponHandlingStateLogic : Logic.States.StateLogic, IOnUpdateLogic
    {
        [SerializeField] private StarterAssetsInputs _inputs = null;
        [SerializeField] private WeaponManager _weaponManager = null;
        
        private bool _deactivated = false;
        
        public override void Activate()
        {
            _deactivated = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if(!_deactivated) return;

            if (_inputs.fire)
                _weaponManager.UseWeapon();
        }

        public override void Deactivate()
        {
            _deactivated = false;
        }
        
    }
}