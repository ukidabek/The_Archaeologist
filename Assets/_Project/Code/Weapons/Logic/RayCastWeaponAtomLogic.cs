using System;
using UnityEngine;

namespace Weapons
{
    public class RayCastWeaponAtomLogic : RangeAttackWeaponAtomLogic, IWeaponBehaviour
    {
        [SerializeField] private float _maxDistance = float.PositiveInfinity;
        [SerializeField] private Damage _damage;
        public void Perform()
        {
            Debug.DrawRay(_origin.position, _origin.forward * 100f, Color.red, 1f);
            if (Physics.Raycast(_origin.position, _origin.forward, out var hit, _maxDistance))
            {
                Debug.Log(hit.transform.name);
                var damageable = hit.transform.gameObject.GetComponent<IDamageable>();
                damageable?.DealDamage(_damage);
            }
        }
    }
}