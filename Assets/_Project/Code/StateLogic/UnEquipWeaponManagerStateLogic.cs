using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class UnEquipWeaponManagerStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private WeaponManager _weaponManager = null;
        
        public override void Activate()
        {
            _weaponManager.Unequip();
        }
    }
}