using Logic.States;
using StarterAssets;
using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class ReloadSwitchStateCondition : SwitchStateCondition
    {
        [SerializeField] private StarterAssetsInputs _inputs = null;

        [SerializeField] private WeaponManager _weaponManager;

        private IClip _clip = null;

        public override bool Condition => _clip != null && (IsClipEmpty || ManualReload);

        private bool ManualReload
        {
            get
            {
                var reload = _inputs.reload;
                _inputs.reload = false;
                return _clip.Count != _clip.Counter && reload;
            }
        }

        private bool IsClipEmpty => _clip.Counter == 0;

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