using System;
using System.Linq;
using UnityEngine;

namespace Weapons
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private WeaponSlot[] _slots = null;
        [SerializeField] private HandSlotBinding[] _bindings = null;
        [SerializeField] private Transform _weaponParentSpot = null;
        
        [Serializable]
        public class HandSlotBinding
        {
            [SerializeField] private HumanBodyBones _humanBone = HumanBodyBones.LeftHand;
            public HumanBodyBones HumanBone => _humanBone;

            [SerializeField] private TransformFollower _transformFollower = null;

            public void SetTransform(Transform transform)
            {
                _transformFollower.SourceTransform = transform;
            }
        }
        
        public WeaponSlot GetSlotForWeapon(Weapon weapon)
        {
            return _slots.FirstOrDefault(slot => slot.ValidateRequirement(weapon.Descriptors));
        }
        
        public void Equip()
        {
            var slot = _slots.FirstOrDefault(slot => slot.Full);
            slot.TakeWeapon(_weaponParentSpot);
            var weapon = slot.StoredWeapon;

            var handSlots = weapon.HandSpots;
            foreach (var handSlot in handSlots)
            {
                var binding = _bindings.FirstOrDefault(slotBinding => slotBinding.HumanBone == handSlot.HumanBone);
                binding.SetTransform(handSlot.SlotTransform);
            }
        }

        public void Unequip()
        {
            var slot = _slots.FirstOrDefault(slot => slot.Full);
            if(slot == null) return;
            foreach (var handSlotBinding in _bindings) 
                handSlotBinding.SetTransform(null);
            slot.PutOffWeapon();
        }
    }
    
}