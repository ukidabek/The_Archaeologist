using Logic.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemButtonController : InventoryButtonControllerBase
{
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] protected Button _button = null;

    public override bool AcceptItem(IItem item) => item is IEquipment;

    public override void Initialize(IItemSlot itemSlot, InventoryController inventoryController)
    {
        base.Initialize(itemSlot, inventoryController);
        _text.text = itemSlot.Item.DisplayName;
        _button.onClick.AddListener(PerformActionOnItem);

    }

    private void PerformActionOnItem()
    {
        var equipment = (IEquipment)_ItemSlot;
        _inventoryController.PassToEquip(equipment);
    }
}