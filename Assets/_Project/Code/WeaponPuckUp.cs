using Interactions;
using UnityEngine;
using Weapons;
using Object = UnityEngine.Object;

namespace PickUps
{
    [RequireComponent(typeof(Weapon))]
    public class WeaponPuckUp : MonoBehaviour, IInteractable
    {
        [SerializeField] private Weapon _weapon = null;
        [SerializeField] private Collider _collider = null;

        public bool Interactable => enabled;

        public void Interact(Object user)
        {
            var userGameObject = user as GameObject;
            if (userGameObject == null) return;
            
            var weaponManager = userGameObject.GetComponent<WeaponManager>();
            weaponManager.EquipToSlot(_weapon);

            _collider.enabled = false;
            enabled = false;
        }

        public void OnSelected()
        {
        }

        public void OnDeselected()
        {
        }

        private void Reset()
        {
            _weapon = GetComponent<Weapon>();
        }
    }
}