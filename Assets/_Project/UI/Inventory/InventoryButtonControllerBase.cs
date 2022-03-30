using Logic.Items;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryButtonControllerBase : MonoBehaviour
{
    [SerializeField] protected InventoryController _inventoryController = null;
    [SerializeField] protected Button _button = null;
    protected IItem _item;
    
    public abstract bool AcceptItem(IItem item);

    public virtual void Initialize(IItem item, InventoryController inventoryController)
    {
        _button.onClick.AddListener(PerformActionOnItem);
        _inventoryController = inventoryController;
        _item = item;
    }
    
    protected abstract void PerformActionOnItem();
}