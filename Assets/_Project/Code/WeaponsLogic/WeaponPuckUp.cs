using Logic.Interactions;
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

        public bool AutoInteraction => false;
        public bool Interactable => enabled;

        public void Interact(Object user)
        {
            var weaponManager = user.GetComponent<WeaponManager>();
            if(weaponManager == null) return;
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