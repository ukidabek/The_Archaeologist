using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Logic.Items
{
    public class ItemCollection<T>: IItemCollection<T> where T:IItemSlot, new()
    {
        private readonly List<T> _itemsSlots;
        public ReadOnlyCollection<T> Items { get; }
        
        public ItemCollection(List<T> _slots)
        {
            Items = new ReadOnlyCollection<T>(_itemsSlots = _slots);
        }

        public void AddItem(IItem item, int count = 1)
        {
            if (item.IsStackable == false || _itemsSlots.Any(itemSlot => itemSlot.Item == item) == false)
            {
                var slot = new T()
                {
                    Item = item,
                    Count = 1
                };
                _itemsSlots.Add(slot);
            }
            else
            {
                var slot = _itemsSlots.First(slot => slot.Item == item);
                slot.Count += count;
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index > _itemsSlots.Count - 1) return new T();
            var itemToReturn = _itemsSlots[index];
            _itemsSlots.RemoveAt(index);
            return itemToReturn;
        }
        
        public IEnumerable<T> GetAll()
        {
            var items = _itemsSlots.ToList();
            _itemsSlots.Clear();
            return items;
        }

        public bool HasItem(IItem item) => _itemsSlots.Any(slot => slot.Item == item);
        public Func<T> CreateSlot { get; }
    }
}