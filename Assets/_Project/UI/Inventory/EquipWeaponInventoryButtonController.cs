using Logic.Items;
using Weapons;

public class EquipWeaponInventoryButtonController : InventoryButtonControllerBase
{
    public override bool AcceptItem(IItem item) => item is WeaponItem;

    public override void PerformActionOnItem()
    {
    }
}