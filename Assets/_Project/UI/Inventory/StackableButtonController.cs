using Logic.Items;
using TMPro;
using UnityEngine;

public class StackableButtonController : InventoryButtonControllerBase
{
    [SerializeField] private TMP_Text _text = null;
    
    public override bool AcceptItem(IItem item) => item.IsStackable;

    public override void Initialize(IItemSlot itemSlot, InventoryController inventoryController)
    {
        base.Initialize(itemSlot, inventoryController);
        _text.text = $"{itemSlot.Item.DisplayName} {itemSlot.Count}";
    }
}