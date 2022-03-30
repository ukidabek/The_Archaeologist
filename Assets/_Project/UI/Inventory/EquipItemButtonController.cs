using Logic.Items;
using TMPro;
using UnityEngine;

public class EquipItemButtonController : InventoryButtonControllerBase
{
    [SerializeField] private TMP_Text _text = null;
    
    public override bool AcceptItem(IItem item) => item is IEquipment;

    public override void Initialize(IItem item, InventoryController inventoryController)
    {
        base.Initialize(item, inventoryController);
        _text.text = item.DisplayName;
    }

    protected override void PerformActionOnItem()
    {
        var equipment = (IEquipment)_item;
        _inventoryController.PassToEquip(equipment);
    }
}