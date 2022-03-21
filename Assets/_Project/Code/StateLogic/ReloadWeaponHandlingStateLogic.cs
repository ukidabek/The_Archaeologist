using System.Linq;
using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class ReloadWeaponHandlingStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private WeaponManager _weaponManager;
        
        public override void Activate()
        {
            var currentWeapon = _weaponManager.CurrentWeapon;
            var clip = currentWeapon.GetWeaponAtomicLogic<IClip>();

            var storage = _weaponManager.AmmunitionStorages.First(
                storage => storage.AmmunitionType == clip.AmmunitionType);
            
            storage.Retrieve(clip);
        }
    }
}