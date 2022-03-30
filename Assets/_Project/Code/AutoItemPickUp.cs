using Logic.Interactions;
using Logic.Items;
using UnityEngine;

public class AutoItemPickUp : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemBase _item;
    [SerializeField] private int _count = 5;

    public bool AutoInteraction => true;
    public bool Interactable => true;

    public void Interact(Object user)
    {
        var inventory = user.GetComponent<Inventory>();
        if (inventory == null) return;

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