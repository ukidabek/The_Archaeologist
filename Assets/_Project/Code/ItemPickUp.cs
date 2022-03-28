using Logic.Interactions;
using Logic.Items;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private Item _item = null;
    [SerializeField] private bool _autoInteraction = false;
    [SerializeField] private int _count = 5;
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
}
