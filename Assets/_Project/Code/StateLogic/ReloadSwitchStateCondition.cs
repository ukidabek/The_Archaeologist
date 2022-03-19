using System;
using Logic.States;
using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class ReloadSwitchStateCondition : SwitchStateCondition
    {
        [SerializeField] private WeaponManager _weaponManager;

        private IClip _clip = null;
        public override bool Condition => _clip != null && _clip.Counter == 0;
        
        public override void Activate()
        {
            var currentWeapon = _weaponManager.CurrentWeapon;
            if (currentWeapon != null)
                _clip = currentWeapon.GetWeaponAtomicLogic<IClip>();
        }

        public override void Deactivate()
        {
            _clip = null;
        }
    }
}