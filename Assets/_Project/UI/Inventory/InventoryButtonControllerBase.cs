using Logic.Items;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryButtonControllerBase : MonoBehaviour
{
    [SerializeField] private InventoryController _inventoryController = null;
    [SerializeField] private Button _button = null;

    public abstract bool AcceptItem(IItem item);

    public virtual void Initialize(IItem item, InventoryController inventoryController)
    {
        _button.onClick.AddListener(PerformActionOnItem);
        _inventoryController = inventoryController;
    }
    
    public abstract void PerformActionOnItem();
}