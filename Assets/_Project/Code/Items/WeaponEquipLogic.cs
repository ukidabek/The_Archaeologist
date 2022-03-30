using Logic.Items;
using UnityEngine;
using Weapons;

public class WeaponEquipLogic : EquipLogicBase
{
    [SerializeField] private WeaponManager _weaponManager = null;
    public override bool CanBeHandled(IEquipment equipment) => equipment is WeaponItem;

    public override void Equip(IEquipment equipment)
    {
        var weaponItem = equipment as WeaponItem;
        var weaponInstance = Instantiate(weaponItem.ItemPrefab);
        var weapon = weaponInstance.GetComponent<Weapon>();
        
        if(weapon == null) return;
        
        _weaponManager.EquipToSlot(weapon);
    }
}