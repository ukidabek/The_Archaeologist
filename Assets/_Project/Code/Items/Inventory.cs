using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Logic.Items;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemCollection<ItemSlot>
{
    [SerializeField] private ItemCollection _itemCollection = null;
    public ItemCollection ItemCollection => _itemCollection;

    public ReadOnlyCollection<ItemSlot> Items { get; }
    public void AddItem(IItem item, int count = 1) => _itemCollection.AddItem(item, count);

    public ItemSlot Get(int index) => _itemCollection.Get(index);

    public IEnumerable<ItemSlot> GetAll() => _itemCollection.GetAll();

    public bool HasItem(IItem item) => _itemCollection.HasItem(item);

    public Func<ItemSlot> CreateSlot => () => new ItemSlot();

    [SerializeField] private EquipLogicBase[] _equipLogic = null;
    
    public void EquipItem(IEquipment equipment)
    {
        var equipLogic = _equipLogic.FirstOrDefault(logic => logic.CanBeHandled(equipment));
        equipLogic?.Equip(equipment);
    }
}