using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logic.Items;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemCollection<ItemSlot>
{
    [SerializeField] private List<ItemSlot> _itemSlots = new List<ItemSlot>();
    
    private ItemCollection<ItemSlot> _itemCollection = null;

    private void Awake()
    {
        _itemCollection = new ItemCollection<ItemSlot>(_itemSlots);
    }

    public ReadOnlyCollection<ItemSlot> Items { get; }
    public void AddItem(IItem item, int count = 1) => _itemCollection.AddItem(item, count);

    public ItemSlot Get(int index) => _itemCollection.Get(index);

    public IEnumerable<ItemSlot> GetAll() => _itemCollection.GetAll();

    public bool HasItem(IItem item) => _itemCollection.HasItem(item);

    public Func<ItemSlot> CreateSlot => () => new ItemSlot();
}