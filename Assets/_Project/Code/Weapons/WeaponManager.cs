using System;
using System.Linq;
using UnityEngine;
using Index = Utilities.General.Index;

namespace Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        private Index _activeSlotIndex = null;
        [SerializeField] private WeaponSlot[] _slots = null;
        [SerializeField] private HandSlotBinding[] _bindings = null;
        
        [Space]
        [SerializeField] private Transform _weaponParentSpot = null;
        [SerializeField] private GameObject _user = null;
        public Weapon CurrentWeapon
        {
            get
            {
                var slot = _slots[_activeSlotIndex];
                if(slot == null || slot.Full == false) return null;
                
                return slot.StoredWeapon;
            }
        }

        public event Action<Weapon> OnWeaponSwitch;  

        private void Awake()
        {
            _activeSlotIndex = new Index(_slots);
        }

        public WeaponSlot GetSlotForWeapon(Weapon weapon)
        {
            return _slots.FirstOrDefault(slot => slot.ValidateRequirement(weapon.Descriptors));
        }
        
        public void Equip()
        {
            var slot = _slots[_activeSlotIndex];
            if(slot == null || slot.Full == false) return;
            
            var weapon = slot.TakeWeapon(_weaponParentSpot);

            weapon.OnEquip(_user);
            var handSlots = weapon.HandSpots;
            foreach (var handSlot in handSlots)
            {
                var binding = _bindings.FirstOrDefault(slotBinding => slotBinding.HumanBone == handSlot.HumanBone);
                binding.SetTransform(handSlot.SlotTransform);
            }
            
            OnWeaponSwitch?.Invoke(weapon);
        }

        public void Unequip()
        {
            var slot = _slots[_activeSlotIndex];
            if(slot == null || slot.Full == false) return;
            
            foreach (var handSlotBinding in _bindings) 
                handSlotBinding.SetTransform(null);
            
            var weapon = slot.PutOffWeapon();
            weapon.OnUnequip(_user);
        }

        public bool UseWeapon()
        {
            var slot = _slots[_activeSlotIndex];
            if(slot == null || slot.Full == false) return false;
            return slot.StoredWeapon.Use();
        }
    }
}