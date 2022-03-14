using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Weapons
{
    public class WeaponSlot : MonoBehaviour
    {
        [SerializeField] private WeaponDescriptor[] _requirements;
        [SerializeField] private Weapon _storedWeapon = null;
        public Weapon StoredWeapon => _storedWeapon;

        public bool Full => _storedWeapon != null;

        public bool ValidateRequirement(IEnumerable<WeaponDescriptor> weponDecriptors)
        {
            var result= _requirements.Intersect(weponDecriptors);
            return _requirements.Length == result.Count();
        }

        public void TakeWeapon(Transform toolTransform)
        {
            ReParentWeapon(toolTransform);
        }

        public void PutOffWeapon()
        {
            ReParentWeapon(transform);
        }

        public void Equip(Weapon weapon)
        {
            _storedWeapon = weapon;
            ReParentWeapon(transform);
        }

        private void ReParentWeapon(Transform parent)
        {
            var weaponTransform = _storedWeapon.transform;
            weaponTransform.SetParent(parent);
            weaponTransform.localPosition = Vector3.zero;
            weaponTransform.localRotation = Quaternion.identity;
        }
    }
}