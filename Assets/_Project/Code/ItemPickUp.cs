using Logic.Interactions;
using Logic.Items;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private Item _item = null;
    [SerializeField] private int _count = 5;
    [SerializeField] private bool _autoInteraction = false;
    [SerializeField] private GameObject _itemPrefabInstance = null;

    public bool AutoInteraction => _autoInteraction;

    public bool Interactable => true;
    public void Interact(Object user)
    {
        var inventory = user.GetComponent<Inventory>();
        if(inventory == null) return;
        
        inventory.AddItem(_item, _count);
        gameObject.SetActive(false);
    }

    public void OnSelected()
    {
    }

    public void OnDeselected()
    {
    }
    
#if UNITY_EDITOR
    [ContextMenu("Create prefab instance")]
    private void CreatePrefabInstance()
    {
        if (_itemPrefabInstance != null)
            DestroyImmediate(_itemPrefabInstance);

        if (_item == null || _item.ItemPrefab == null) return;

        var prefabInstance = UnityEditor.PrefabUtility.InstantiatePrefab(_item.ItemPrefab);
        _itemPrefabInstance = prefabInstance as GameObject;
        var prefabInstanceTransform = _itemPrefabInstance.transform;
        prefabInstanceTransform.SetParent(transform);
        prefabInstanceTransform.localPosition = Vector3.zero;
        prefabInstanceTransform.localRotation = quaternion.identity;
        name = prefabInstance.name;
    }
#endif
}