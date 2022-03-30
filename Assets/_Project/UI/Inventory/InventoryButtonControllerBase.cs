using Logic.Items;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryButtonControllerBase : MonoBehaviour
{
    [SerializeField] protected InventoryController _inventoryController = null;
    protected IItemSlot _ItemSlot;
    
    public abstract bool AcceptItem(IItem item);

    public virtual void Initialize(IItemSlot itemSlot, InventoryController inventoryController)
    {
        _inventoryController = inventoryController;
        _ItemSlot = itemSlot;
    }
}