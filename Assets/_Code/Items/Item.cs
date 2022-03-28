using UnityEngine;

namespace Logic.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Equipment/Item")]
    public class Item : ScriptableObject, IItem
    {
        public string Name => name;
        
        [SerializeField] private string _displayName = string.Empty;
        public string DisplayName => _displayName;
        
        [SerializeField] private bool _isStackable = false;
        public bool IsStackable => _isStackable;
    }
}