using System;
using Logic.States;
using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class WeaponSelectedCondition : SwitchStateCondition
    {
        public enum Mode { IsNull, IsNotNull }

        [SerializeField] private Mode _mode = Mode.IsNull;
        [SerializeField] private WeaponManager _weaponManager;
        
        public override bool Condition
        {
            get
            {
                return _mode switch
                {
                    Mode.IsNull => _weaponManager.CurrentWeapon == null,
                    Mode.IsNotNull => _weaponManager.CurrentWeapon != null,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}