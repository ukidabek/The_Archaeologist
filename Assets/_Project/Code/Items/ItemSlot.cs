using System;
using Logic.Items;
using UnityEngine;

[Serializable]
public class ItemSlot : IItemSlot
{
    [SerializeField] private Item _item;

    public IItem Item
    {
        get => _item;
        set
        {
            if (value is Item item)
                _item = item;
        }
    }

    [SerializeField] private int _count;
    public int Count
    {
        get => _count;
        set => _count = value;
    }
}