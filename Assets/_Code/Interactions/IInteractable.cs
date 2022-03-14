namespace Interactions
{
    public interface IInteractable
    {
        bool Interactable { get; }
        void Interact(UnityEngine.Object user);
        void OnSelected();
        void OnDeselected();
    }
}