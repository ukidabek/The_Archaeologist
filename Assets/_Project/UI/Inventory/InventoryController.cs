using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.UI;
using Weapons;

public class InventoryController :  ManagerModelViewBase<Inventory, InventoryModel>
{
    public ItemCollection ItemCollection => Manager.ItemCollection;
    [SerializeField] private WeaponManagerModel _weaponManagerModel = null;

    public WeaponManagerModel WeaponManagerModel => _weaponManagerModel;

    [SerializeField] private InventoryButtonControllerBase[] _buttonControllers = null;

    [Space] [SerializeField]
    private List<InventoryButtonControllerBase> _buttonInstances = new List<InventoryButtonControllerBase>();

    [SerializeField] private Transform _buttonParent = null;
    
    private void OnEnable()
    {
        var items = ItemCollection.Items;

        foreach (var itemSlot in items)
        {
            var item = itemSlot.Item;
            var prefab = _buttonControllers.FirstOrDefault(baseButton => baseButton.AcceptItem(item));
            var instance = Instantiate(prefab, _buttonParent, false);
            instance.Initialize(item, this);
            _buttonInstances.Add(instance);
        }
    }

    private void OnDisable()
    {
        if(_buttonInstances.Any() == false) return;
        foreach (var inventoryButton in _buttonInstances) 
            Destroy(inventoryButton.gameObject);
    }
}