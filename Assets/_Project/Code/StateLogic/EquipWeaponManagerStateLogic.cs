using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class EquipWeaponManagerStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private WeaponManager _weaponManager = null;
        
        public override void Activate()
        {
            _weaponManager.Equip();
        }
    }
}