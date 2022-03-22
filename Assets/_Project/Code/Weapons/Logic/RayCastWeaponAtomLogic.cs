using UnityEngine;

namespace Weapons
{
    public class RayCastWeaponAtomLogic : RangeAttackWeaponAtomLogic, IWeaponBehaviour
    {
        [SerializeField] private float _maxDistance = float.PositiveInfinity;
        [SerializeField] private Damage _damage;
        public void Perform()
        {
            
            if (Physics.Raycast(_origin.position, _origin.forward, out var hit, _maxDistance))
            {
                Debug.DrawLine(_origin.position, hit.point, Color.green, 1f);
                Debug.Log(hit.transform.name);
                var damageable = hit.transform.gameObject.GetComponent<IDamageable>();
                damageable?.DealDamage(_damage);
            }
            else
                Debug.DrawRay(_origin.position, _origin.forward * 100f, Color.red, 1f);

        }
    }
}