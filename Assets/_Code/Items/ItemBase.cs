using UnityEngine;

namespace Logic.Items
{
    public abstract  class ItemBase : ScriptableObject, IItem
    {
        public abstract string Name { get; }
        public abstract string DisplayName { get; }
        public abstract bool IsStackable { get; }
    }
}