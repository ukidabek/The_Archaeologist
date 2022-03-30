using System;
using Logic.Items;
using UnityEngine;

[Serializable]
public class ItemSlot : IItemSlot
{
    [SerializeField] private ItemWitchPrefab _item;

    public IItem Item
    {
        get => _item;
        set
        {
            if (value is ItemWitchPrefab item)
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